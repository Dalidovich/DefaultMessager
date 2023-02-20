using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class ImageAlbumController : Controller
    {
        private readonly ILogger<ImageAlbumController> _logger;
        private readonly ImageAlbumService<ImageAlbum> _imageAlbumService;

        public ImageAlbumController(ILogger<ImageAlbumController> logger, ImageAlbumService<ImageAlbum> service)
        {
            _logger = logger;
            _imageAlbumService = service;
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
