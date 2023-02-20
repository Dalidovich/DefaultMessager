using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly MessageService<Message> _messageAlbumService;

        public MessageController(ILogger<MessageController> logger, MessageService<Message> service)
        {
            _logger = logger;
            _messageAlbumService = service;
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
