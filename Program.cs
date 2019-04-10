using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyAspNetCoreApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateWebHostBuilder(args).Build().Run();
            var host = new WebHostBuilder()
                .UseKestrel() //setup a web-server Kestrel
                .UseContentRoot(Directory.GetCurrentDirectory()) // configure the application root directory
                .UseIISIntegration() // provide integration with IIS
                .UseStartup<Startup>() // install the main application file
                .Build(); // create host
            host.Run(); // run host
        }

        //Method for start web application
        // public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //     WebHost.CreateDefaultBuilder(args)
        //         .UseStartup<Startup>();
    }
}
