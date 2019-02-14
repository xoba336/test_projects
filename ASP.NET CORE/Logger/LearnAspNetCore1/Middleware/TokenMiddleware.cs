using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspNetCore1
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;

        public TokenMiddleware(RequestDelegate next, string token)
        {
            this._next = next;
            this._token = token;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != _token)
            {
                context.Response.StatusCode = 403;
                context.Response.WriteAsync("Token not valid!");
            }
            else
            {
                await _next(context);
            }
        }
    }
    public static class TokenExtensions
    {
        public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string token)
        {
            return builder.UseMiddleware<TokenMiddleware>(token);
        }
    }
}
