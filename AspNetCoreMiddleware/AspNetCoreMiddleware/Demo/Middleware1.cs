using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCoreMiddleware.Demo
{
    public class Middleware1
    {
        private readonly RequestDelegate _next;

        public Middleware1(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Middleware 1 (antes)\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Middleware 1 (depois)\n");
        }
    }

    public static class Middleware1Extensions
    {
        public static IApplicationBuilder UseMiddleware1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware1>();
        }
    }
}
