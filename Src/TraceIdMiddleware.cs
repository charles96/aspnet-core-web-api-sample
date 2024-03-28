namespace aspnet_core_web_api_sample
{
    public class TraceIdMiddleware
    {
        private readonly RequestDelegate _next;

        public TraceIdMiddleware(RequestDelegate next)
            => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            context.TraceIdentifier = Guid.NewGuid().ToString();
            context.Response.OnStarting(() =>
            {
                context.Response.Headers["X-Trace-Id"] = context.TraceIdentifier;
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
