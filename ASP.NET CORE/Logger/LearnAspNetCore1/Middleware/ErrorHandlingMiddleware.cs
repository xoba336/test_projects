using LearnAspNetCore1.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspNetCore1
{
    public class ErrorHandlingMiddleware: MiddlewareBase
    {
        public ErrorHandlingMiddleware(RequestDelegate next, LoggerFactory logger) :base(next, logger)
        {

        }

        public override async Task InvokeAsync(HttpContext context)
        {
            ILogger logger = _logger.CreateLogger("Error");
            logger.LogInformation("--========================Errror, Path{0}", context.Request.Path);

            await _next(context);
            if (context.Response.StatusCode == 403)
                await context.Response.WriteAsync("Access Denied.");
            else if (context.Response.StatusCode == 404)
                await context.Response.WriteAsync("Not Found.");
        }
    }
}
