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

                _logger.LogInformation("Error happen in middleware"+e.StackTrace+e.Message); 

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("שגיאה לא צפויה?!");


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
