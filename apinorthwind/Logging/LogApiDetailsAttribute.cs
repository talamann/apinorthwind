using Microsoft.AspNetCore.Mvc.Filters;
using System.Numerics;

namespace apinorthwind.Logging
{
    public class LogApiDetailsAttribute : ActionFilterAttribute
    {
       
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            var apiLog = new APILog
            {

                RequestUrl = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}",
                HttpMethod = request.Method,
                RequestBody = GetRequestBody(context.HttpContext),
                ResponseBody = GetResponseBody(context.HttpContext),
                timeof = DateTime.Now,
                EndPoint = GetEndpointForLog(context.HttpContext)
            };

            using (var scope = context.HttpContext.RequestServices.CreateScope())
            {
                var apiLogService = scope.ServiceProvider.GetRequiredService<APILogService>();
                apiLogService.LogApiDetails(apiLog);
            }

            base.OnActionExecuted(context);
        }

        private string GetRequestBody(HttpContext context)
        {
            return context.Request.Body.ToString();
        }

        private string GetResponseBody(HttpContext context)
        {
            return context.Response.StatusCode.ToString();
        }
        private string GetEndpointForLog(HttpContext context)
        {
            return context.GetEndpoint().ToString();
        }
    }
}
