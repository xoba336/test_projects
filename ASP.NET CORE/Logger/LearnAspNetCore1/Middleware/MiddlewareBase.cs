using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspNetCore1.Middleware
{
    public abstract class MiddlewareBase
    {
        protected RequestDelegate _next;
        protected LoggerFactory _logger;
        public MiddlewareBase(RequestDelegate next, LoggerFactory logger)
        {
            _next = next;
            _logger = logger;
        }

        public virtual async Task InvokeAsync(HttpContext context)
        {

        }
    }
}
