using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreMiddleware
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 1 (antes)\n");
                await next();
                await context.Response.WriteAsync("Middleware 1 (depois)\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 2 (antes)\n");
                await next();
                await context.Response.WriteAsync("Middleware 2 (depois)\n");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Middleware final\n");
            });
        }
    }
}
