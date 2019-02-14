using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace LearnAspNetCore1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //BuildWebHost(args).Run();
            /*using (var host = WebHost.Start("http://localhost:8080", context => context.Response.WriteAsync("Web Host Hello....")))
            {
                Console.WriteLine("App started");
                host.WaitForShutdown();
                
            }*/

            /*var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
            host.Run();*/
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //.ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Trace))
                .UseWebRoot(@"wwwroot\static");

        /*public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()          // установка класса Startup как стартового
            .UseWebRoot(@"wwwroot\static")   // установка папки static
            .Build();*/

    }
}
