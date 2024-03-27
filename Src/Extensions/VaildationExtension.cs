using aspnet_core_web_api_sample.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace aspnet_core_web_api_sample.Extensions
{
    public static class VaildationExtension
    {
        public static UserResponse GetValidationResult(this ModelStateDictionary modelStateDictionary)
        {
            return new UserResponse()
            {
                Success = false,
                InvalidList = modelStateDictionary
                                        .Where(o => o.Value.Errors.Any())
                                        .Select(o => o.Value.Errors[0].ErrorMessage)
                                        .ToArray()
            };
        }
    }
}
