using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.AccountSpecification;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionAccountSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountService<Account> _accountService;
        private readonly DescriptionAccountService<DescriptionAccount> _descriptionAccountService;

        public AccountController(ILogger<AccountController> logger, AccountService<Account> service, DescriptionAccountService<DescriptionAccount> descriptionAccountService)
        {
            _logger = logger;
            _accountService = service;
            _descriptionAccountService = descriptionAccountService;
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
                    Response.Cookies.setJwtCookie(responce.Data);
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
                    Response.Cookies.setJwtCookie(responce.Data);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", responce.Description);
            }
            return View(model);
        }
        public IActionResult LogOut()
        {
            Response.Cookies.removeJwtCookie();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Index(string? login = null)
        {
            login = login ?? User.Identity.Name;
            var accountByLogin = new AccountProfileByLogin<AccountProfileViewModel>(login);
            var response = await _accountService.GetProfile(accountByLogin.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.AccountRead)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
        [HttpPost]
        public async Task<IActionResult> EditDescription(DescriptionAccount model, Guid id)
        {
            var descriptionById = new DescriptionAccountById<DescriptionAccount>(id);
            var descriptionAccount = await _descriptionAccountService.GetOne(descriptionById.ToExpression());
            var forUpdate = descriptionAccount.Data;
            forUpdate.Update(model);
            var response = await _descriptionAccountService.Update(forUpdate);
            if (response.StatusCode == Domain.Enums.StatusCode.EntityUpdate)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        [HttpGet]
        public async Task<IActionResult> EditDescription(Guid descriptionId)
        {
            var postById = new DescriptionAccountById<DescriptionAccount>(descriptionId);
            var response = await _descriptionAccountService.GetOne(postById.ToExpression());
            if (response.StatusCode == Domain.Enums.StatusCode.EntityRead)
            {
                return PartialView(response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
