using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DefaultMessager.Domain.JWT;
using Microsoft.AspNetCore.Http;

namespace DefaultMessager.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService<Account> _accountService;

        public AccountController(ILogger<AccountController> logger, AccountService<Account> service)
        {
            _logger = logger;
            _accountService = service;
        }

        private void setJWTTokenComponentInCookie((string, RefreshToken,Guid) jwtComponent)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
            };
            Response.Cookies.Append("JWTToken", jwtComponent.Item1, cookieOptions);
            Response.Cookies.Append("RefreshToken", jwtComponent.Item2.Token, cookieOptions);
            Response.Cookies.Append("Id", jwtComponent.Item3.ToString(), cookieOptions);

        }

        [HttpGet]
        public IActionResult Registration() => View();
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var responce = await _accountService.Registration(model);
                if (responce.StatusCode == Domain.Enums.StatusCode.AccountCreate)
                {
                    setJWTTokenComponentInCookie(responce.Data);                    
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", responce.Description);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult LogIn() => View();
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var responce = await _accountService.Authenticate(model);
                if (responce.StatusCode == Domain.Enums.StatusCode.AccountAuthenticate)
                {
                    setJWTTokenComponentInCookie(responce.Data);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", responce.Description);
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            Response.Cookies.Delete("JWTToken");
            Response.Cookies.Delete("RefreshToken");
            Response.Cookies.Delete("Id");
            return RedirectToAction("Index", "Home");
        }
    }
}
