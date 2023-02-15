using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.JWT
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AccountService<Account> _accountService;

        public JWTMiddleware(RequestDelegate next/*, AccountService<Account> accountService*/)
        {
            _next = next;
            //_accountService = accountService;
        }
        public async Task InvokeAsync(HttpContext context, AccountService<Account> accountService)
        {
            string? token = context.Request.Cookies["JWTToken"];
            string? refreshToken = context.Request.Cookies["RefreshToken"];
            string? id = context.Request.Cookies["Id"];
            if (!context.User.Identity.IsAuthenticated && refreshToken != null && id != null)
            {
                var response = (await accountService.RefreshJWTToken(new Guid(id), refreshToken)).Data;
                if (response.Item2 is not null)
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                    };
                    context.Response.Cookies.Append("JWTToken", response.Item1,cookieOptions);
                    context.Response.Cookies.Append("RefreshToken", response.Item2, cookieOptions);
                    context.Response.Cookies.Append("Id", response.Item3.ToString(), cookieOptions);
                    token = response.Item1;
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
