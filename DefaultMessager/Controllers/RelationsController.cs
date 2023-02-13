using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class RelationsController : Controller
    {
        private readonly ILogger<RelationsController> _logger;
        private readonly RelationsService<Relations> _relationAlbumService;

        public RelationsController(ILogger<RelationsController> logger, RelationsService<Relations> service)
        {
            _logger = logger;
            _relationAlbumService = service;
        }

        [HttpGet]
        public ActionResult Registration() => View();
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var responce = await _accountService.Registration(model);
                //if (responce.StatusCode == Domain.Enums.StatusCode.AccountCreate)
                //{

                //    return RedirectToAction("Index", "Home");
                //}
                //ModelState.AddModelError("", responce.Description);
            }
            return View(model);
        }
    }
}
