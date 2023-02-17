using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILogger<LikeController> _logger;
        private readonly LikeService<Like> _likeAlbumService;

        public LikeController(ILogger<LikeController> logger, LikeService<Like> service)
        {
            _logger = logger;
            _likeAlbumService = service;
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
