using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace WebAppLoginEx1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareErrors
    {
        private readonly RequestDelegate _next;
        ILogger<MiddlewareErrors> _logger;

        public MiddlewareErrors(RequestDelegate next, ILogger<MiddlewareErrors> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try { 
            await _next(httpContext);
            }
            catch(Exception e)
            { 

                httpContext.Response.StatusCode = 500;
                _logger.LogError("Error happen in middleware"+e.StackTrace+e.Message+"we are sorry..."); 
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareErrorsExtensions
    {
        public static IApplicationBuilder UseMiddlewareErrors(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareErrors>();
        }
    }
}
