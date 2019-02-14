using LearnAspNetCore1.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspNetCore1
{
    public class RoutingMiddleware: MiddlewareBase
    {
        public RoutingMiddleware(RequestDelegate next, LoggerFactory logger) :base(next, logger)
        {

        }
        public override async Task InvokeAsync(HttpContext context)
        {
            var logger = _logger.CreateLogger("Rout");
            string path = context.Request.Path.Value.ToLower();
            if (path == "/" || path == "/index")
            {
                //var logger
                await context.Response.WriteAsync("Home Page");
                logger.LogInformation("--======================At Home Page");
            }
            else if (path == "/contact")
            {
                logger.LogInformation("--======================At Contact");
                await context.Response.WriteAsync("Contact.");
            }
            else if (path == "/product")
            {
                logger.LogInformation("--======================At Product");
                await context.Response.WriteAsync("Products.");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }
    }
}
