using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.BLL.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, AccountService<Account> accountService)
        {
            string? token = context.Request.Cookies[CookieNames.JWTToken];
            string? refreshToken = context.Request.Cookies[CookieNames.RefreshToken];
            string? id = context.Request.Cookies[CookieNames.AccountId];
            if (!context.User.Identity.IsAuthenticated && refreshToken != null && id != null)
            {
                var response = (await accountService.RefreshJWTToken(new Guid(id), refreshToken)).Data;
                if (response.Item2 is not null)
                {
                    context.Response.Cookies.setJwtCookie(response);
                    token = response.Item1;
                }
                else
                {
                    context.Response.Cookies.removeJwtCookie();
                }
            }

            if (token != null)
            {
                context.Request.Headers.Add("Authorization", "Bearer " + token);
            }
            await _next.Invoke(context);
        }
    }
}
