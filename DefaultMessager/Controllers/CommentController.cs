using Microsoft.AspNetCore.Mvc;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly CommentService<Comment> _commentService;

        public CommentController(ILogger<CommentController> logger, CommentService<Comment> service)
        {
            _logger = logger;
            _commentService = service;
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
