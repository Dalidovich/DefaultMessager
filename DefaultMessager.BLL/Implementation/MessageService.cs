using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.AccountRepositores;
using DefaultMessager.DAL.Repositories.MessageRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.Specification.CompositeSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.MessageModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class MessageService<T> : BaseService<T>, IMessageService where T : Message
    {
        private readonly MessageNavRepository _navMessageRepository;

        public MessageService(IBaseRepository<T> repository, ILogger<T> logger,MessageNavRepository messageNavRepository) : base(repository, logger)
        {
            _navMessageRepository = messageNavRepository;
        }
        public async Task<BaseResponse<IEnumerable<MessageViewModel>>> GetMessagesBetween(Guid firstAccountId, Guid secondAccountId)
        {
            try
            {
                var messageByResieve1 = new MessageViewModelByRecieveId<MessageViewModel>(firstAccountId);
                var messageBySender1 = new MessageViewModelBySenderId<MessageViewModel>(firstAccountId);
                var messageByResieve2 = new MessageViewModelByRecieveId<MessageViewModel>(secondAccountId);
                var messageBySender2 = new MessageViewModelBySenderId<MessageViewModel>(secondAccountId);
                var or1Spec = new OrSpecification<MessageViewModel>(messageBySender1, messageByResieve1);
                var or2Spec = new OrSpecification<MessageViewModel>(messageBySender2, messageByResieve2);
                var andSpec = new AndSpecification<MessageViewModel>(or1Spec, or2Spec);
                var response = await _navMessageRepository.GetMessageInCorrespondence(andSpec.ToExpression())
                    .OrderBy(x=>x.SendDateTime).ToListAsync();
                return new StandartResponse<IEnumerable<MessageViewModel>>()
                {
                    Data = response??new List<MessageViewModel>(),
                    StatusCode = Domain.Enums.StatusCode.MessageRead
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetMessagesBetween] : {ex.Message}");
                return new StandartResponse<IEnumerable<MessageViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

    }
}
