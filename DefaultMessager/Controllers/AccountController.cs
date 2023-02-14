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
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                    };
                    Response.Cookies.Append("JWTToken", responce.Data, cookieOptions);
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

                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                    };
                    Response.Cookies.Append("JWTToken", responce.Data, cookieOptions);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", responce.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            Response.Cookies.Delete("JWTToken");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> test()
        {
            Console.WriteLine("ok");
            return View();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> testAdmin()
        {
            Console.WriteLine("ok");
            return View();
        }

        [Authorize(Roles = "standart")]
        public async Task<IActionResult> testStandart()
        {
            Console.WriteLine("ok");
            return View();
        }
    }
}
