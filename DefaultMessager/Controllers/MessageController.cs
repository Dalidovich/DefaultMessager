using DefaultMessager.BLL.Implementation;
using DefaultMessager.Domain.Entities;
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
    }
}
