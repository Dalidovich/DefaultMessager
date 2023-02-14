using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.JWT
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string? token = context.Request.Cookies["JWTToken"];
            if (token != null)
            {
                context.Request.Headers.Add("Authorization", "Bearer " + token);
            }                
            await _next.Invoke(context);
        }
    }
}
