using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefaultMessager.Controllers
{
    public class MessageController : Controller
    {
        private readonly ILogger<MessageController> _logger;
        private readonly MessageService<Message> _messageService;

        public MessageController(ILogger<MessageController> logger, MessageService<Message> service)
        {
            _logger = logger;
            _messageService = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetPartialMessages(int? id, Guid? companionId)
        {
            var page = id ?? 0;
            var accountAuthId = new Guid(User.Identities.First().FindFirst(CustomClaimType.AccountId).Value);
            var response = await _messageService.GetMessagesBetween(accountAuthId, (Guid)companionId,page);
            if (response.StatusCode == Domain.Enums.StatusCode.MessageRead)
            {
                return PartialView("~/Views/Chatting/_messagesBetween.cshtml", response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
