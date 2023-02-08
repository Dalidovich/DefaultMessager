using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.Service.Implementation
{
    public class MessageService<T> : BaseService<T>, IMessageService where T : Message
    {
        public MessageService(IBaseRepository<T> repository, ILogger<T> logger) : base(repository, logger)
        {
        }
    }
}
