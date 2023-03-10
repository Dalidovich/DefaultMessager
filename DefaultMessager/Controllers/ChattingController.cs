using DefaultMessager.BLL.Implementation;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class ChattingController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IChattingService _chattingService;

        public ChattingController(ILogger<AccountController> logger,IChattingService chattingService)
        {
            _logger = logger;
            _chattingService = chattingService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var authId = new Guid(User.Identities.First().FindFirst(CustomClaimType.AccountId).Value);
            var response=await _chattingService.GetChattingViewModel(authId);
            if (response.StatusCode == Domain.Enums.StatusCode.ChattingModelCreate)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
