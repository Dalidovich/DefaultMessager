using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using Microsoft.AspNetCore.Http;

namespace DefaultMessager.BLL.Middleware
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;

        public JWTMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRegistrationService registrationService)
        {
            string? token = context.Request.Cookies[CookieNames.JWTToken];
            string? refreshToken = context.Request.Cookies[CookieNames.RefreshToken];
            string? id = context.Request.Cookies[CookieNames.AccountId];
            if (context.User.Identity is not null && !context.User.Identity.IsAuthenticated && refreshToken != null && id != null)
            {
                var response = (await registrationService.RefreshJWTToken(new Guid(id), refreshToken)).Data;
                if (response.Item2 is not null)
                {
                    context.Response.Cookies.setJwtCookie(response);
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
