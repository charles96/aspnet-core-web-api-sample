namespace aspnet_core_web_api_sample
{
    public class TraceIdMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string xTraceId = "x-trace-id";

        public TraceIdMiddleware(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            context.TraceIdentifier = Guid.NewGuid().ToString();
            context.Response.OnStarting(() =>
            {
                var traceId = context.Request.Headers[xTraceId];

                if (String.IsNullOrWhiteSpace(traceId)) 
                    traceId = context.TraceIdentifier;

                context.Response.Headers[xTraceId] = traceId;
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
