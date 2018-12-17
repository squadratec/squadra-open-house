using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreMiddleware.Demo
{
    public class MiddlewareFinal
    {
        private readonly RequestDelegate _next;

        public MiddlewareFinal(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Middleware Final\n");
        }
    }

    public static class MiddlewareFinalExtensions
    {
        public static IApplicationBuilder UseMiddlewareFinal(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareFinal>();
        }
    }
}
