using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace empty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            var nodeModulesPath = Path.Combine(env.ContentRootPath, "node_modules");
            var staticFileOptions = new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(nodeModulesPath)
            };
            app.UseStaticFiles(staticFileOptions);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/a{text}", async context =>
                {
                    var text = context.Request.RouteValues["text"];
                    await context.Response.WriteAsync($"A {text}");
                });
            });

            app.UseWelcomePage();
        }
    }
}
