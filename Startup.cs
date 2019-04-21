using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyAspNetCoreApp
{
    public class Startup
    {
        // string name;
        public Startup()
        {
            // name = "Kirill";
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) // if application status development = true
            {
                app.UseDeveloperExceptionPage(); // if error print
            }
            app.UseStaticFiles();
            // int x = 5;
            // int y = 2;
            // int z = 0;
            // app.Use(async (context, next) => {
            //     z = x * y;
            //     await next();
            //     z = z * 5;
            //     await context.Response.WriteAsync($"z = {z}");
            // });
            // app.Run(Handle);
            app.Map("/index", Index);
            app.Run(async (context) => {
                // z = z * 2;
                // await Task.FromResult(0);
                await context.Response.WriteAsync("404");
            });

        }
        private async Task Handle (HttpContext context) {
                string host = context.Request.Host.Value;
                string path = context.Request.Path;
                string query = context.Request.QueryString.Value;
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"<h3>Хост:{host}</h3>" + 
                    $"<h3>Путь запроса:{path}</h3>" +
                    $"<h3>Параметры строки запроса:{query}</h3>");

        }
        private static void Index(IApplicationBuilder app) {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Index");
            });
        }       
    }
}
