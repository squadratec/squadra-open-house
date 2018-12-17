using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreMiddleware.Demo
{
    public class Middleware2
    {
        private readonly RequestDelegate _next;

        public Middleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Middleware 2 (antes)\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Middleware 2 (depois)\n");
        }
    }

    public static class Middleware2Extensions
    {
        public static IApplicationBuilder UseMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware2>();
        }
    }
}
