using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LearnAspNetCore1.Loger;
using System.IO;

namespace LearnAspNetCore1
{
    public class Startup
    {
        RequestDelegate _next;
        string name;
        public Startup()
        {
            name = "Some string in CTRO...";
            Console.WriteLine("CTOR.....");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddDirectoryBrowser();

        }
        // public delegate Task RequestDelegate(HttpContext context);
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {


            //loggerFactory.AddConsole();
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var q1 = env.ApplicationName;
            var q2 = env.EnvironmentName;
            var q3 = env.WebRootPath;
            var q4 = env.ContentRootFileProvider;
            var q5 = env.WebRootFileProvider;


            //app.UseDirectoryBrowser();
            //app.UseDefaultFiles(); //index.html, default.html from wwroot
            app.UseStaticFiles();
            
            app.UseMiddleware<ErrorHandlingMiddleware>(loggerFactory);
            app.UseMiddleware<AuthentificationMiddleware>(loggerFactory);
            app.UseMiddleware<RoutingMiddleware>(loggerFactory);




            //-------Test
            /*
            //app.UseMiddleware<TokenMiddleware>();
            app.UseToken("123");

            app.Map("/home", home =>
            {
                home.Map("/index", Index);
                home.Map("/contact", Contact);
                //home.Map("/product", Product);

                home.Map("/product", product =>
                {
                        product.MapWhen(context =>
                        {
                            return context.Request.Query.ContainsKey("id") &&
                            context.Request.Query["id"] == "5";
                        }, HandleId);
                });
                    
            });

            //int x = 5;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseStaticFiles();
            //app.UseAuthentication();
            //app.UseCookiePolicy();
            //app.UseStaticFiles();
            int x = 5;
            int y = 2;
            int z = 0;

            app.Use(async (context, next) => {
                await context.Response.WriteAsync(@" USE1---");
                z = x * y;
                await next();
                z = z * 5;
                await context.Response.WriteAsync(@" USE2---");
                await context.Response.WriteAsync($"z = {z}");
            });

            app.Run(Handle);
            */



            /*app.Run(async(context) => {
                await context.Response.WriteAsync(@" RUN1---");
                z = z * 2;
                await context.Response.WriteAsync($"x = {x}, y = {y}, z = {z}");
                //await Task.FromResult(0);
            });*/
            //-------Test


            //app.Run(async (context) => await context.Response.WriteAsync("Hellllllo1"));
        }
        private static void Product(IApplicationBuilder app)
        {
            app.MapWhen( context => {
                return context.Request.Query.ContainsKey("id") &&
                context.Request.Query["id"] == 5;
            } ,HandleId);

            //app.Run(async context => { await context.Response.WriteAsync("All Products."); });
        }

        private static void HandleId(IApplicationBuilder app)
        {
            app.Run(async context => {
                await context.Response.WriteAsync("Id = 5");
            });
        }

        private static void Index(IApplicationBuilder app)
        {
            app.Run(async context => {
                await context.Response.WriteAsync("Index app");
            });
        }
        
        private static void Contact(IApplicationBuilder app)
        {
            app.Run(async context => {
                context.Response.WriteAsync("Contact.");
            });
        }

        private async Task Handle(HttpContext context)
        {
                //x = x + 1;
                //x = x * 2;
                //await context.Response.WriteAsync(String.Format("Hello World! - {0} - x = {1}", name, x));

                string host = context.Request.Host.Value;
                string path = context.Request.Path.Value;
                string query = context.Request.QueryString.Value;
                string browser = context.Request.Headers["User-Agent"];//.FirstOrDefault();
                //UserAgent.UserAgent ua = new UserAgent.UserAgent(browser);


                if (!path.Contains("favicon"))
                {
                    // x = x * 2;
                    //await context.Response.WriteAsync(String.Format(@"browser: "+ browser + " \n Hello World! - {0} - x = {1}", name, x));

                    //context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync($"<h3>Хост:{host}</h3>" +
                        $"<h3>Путь:{path}</h3>" +
                        $"<h3>Параметры:{query}</h3>");
                    //await context.Response.WriteAsync("Hello World!}");
                }
        }

    }
}
