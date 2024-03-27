using aspnet_core_web_api_sample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnet_core_web_api_sample
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is Exception)
            {
                context.Result = new ObjectResult(new UserResponse()
                {
                    Success = false,
                    Message = "unknown error"
                })
                {
                    StatusCode = 500
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
