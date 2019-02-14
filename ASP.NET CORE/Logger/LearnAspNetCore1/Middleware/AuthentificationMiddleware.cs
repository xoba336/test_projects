using LearnAspNetCore1.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspNetCore1
{
    public class AuthentificationMiddleware : MiddlewareBase
    {
        bool _authentification;
        public AuthentificationMiddleware(RequestDelegate next, LoggerFactory logger):base(next, logger)
        {

        }
        public override async Task InvokeAsync(HttpContext context)
        {
            var logger = _logger.CreateLogger("Authentification");
            
            var token = context.Request.Query["token"];
            if (String.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = 403;
                logger.LogInformation("--======================Authentification failed");
                _authentification = false;
            }
            else

            {

                if (!_authentification)
                {
                    logger.LogInformation("--======================Authentification OK.");
                    _authentification = true;
                }
                await _next(context);
            }
        }
    }
}
