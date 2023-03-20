using DefaultMessager.BLL.Implementation;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Specification.CompositeSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.CommentSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification;
using DefaultMessager.Domain.ViewModel.MessageModel;
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
                if (response.Data.Count() != 0)
                {
                    return PartialView("~/Views/Chatting/_messagesBetween.cshtml", response.Data);
                }
                else
                {
                    return PartialView("~/Views/_ViewImports.cshtml");
                }
            }
            return RedirectToAction("Error");
        }

        [Authorize]
        public async Task<IActionResult> SendMessage(Guid companionId, string messageContent)
        {
            string? id = Request.Cookies[CookieNames.AccountId];
            if (id != null && messageContent != "")
            {
                var createResponse = await _messageService.Add(
                    new Message(companionId, new Guid(id), new string[]{ }, new string[]{ },DateTime.Now,StatusMessage.normal,messageContent));
                if (createResponse.StatusCode == Domain.Enums.StatusCode.EntityCreate)
                {
                    MessageViewModel messageViewModel= new MessageViewModel(createResponse.Data);
                    return PartialView("~/Views/Chatting/_messagesBetween.cshtml", new List<MessageViewModel> {messageViewModel});
                }
            }
            return RedirectToAction("Error");
        }

        [Authorize]
        public async Task<IActionResult> GetMessage(string content)
        {
            return PartialView("~/Views/Chatting/_resievedMessage.cshtml", content);
        }
    }
}
