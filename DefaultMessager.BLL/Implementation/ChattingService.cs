using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.DAL.Repositories.RelationsRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.Specification.CompositeSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.MessageSpecification;
using DefaultMessager.Domain.Specification.CustomSpecification.RelationSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Domain.ViewModel.ChattingModel;
using DefaultMessager.Domain.ViewModel.MessageModel;
using DefaultMessager.Domain.ViewModel.PostModel;
using DefaultMessager.Domain.ViewModel.RelationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class ChattingService : IChattingService
    {
        protected readonly ILogger<ChattingService> _logger;
        private readonly AccountService<Account> _accountService;
        private readonly MessageService<Message> _messageService;
        private readonly RelationsService<Relations> _relationsService;

        public ChattingService(ILogger<ChattingService> logger, AccountService<Account> accountService
            , MessageService<Message> messageService, RelationsService<Relations> relationsService)
        {
            _logger = logger;
            _accountService = accountService;
            _messageService = messageService;
            _relationsService = relationsService;
        }

        public async Task<BaseResponse<ChattingViewModel>> GetChattingViewModel(Guid accountId)
        {
            try
            {
                var icons = await _relationsService.GetListAccountIconInCorrespondence(accountId);
                AccountIconViewModel companion=null;
                AccountIconViewModelById<AccountIconViewModel> accById= null;
                List<MessageViewModel> messages = new List<MessageViewModel>();
                if (icons.Data.Count() != 0)
                {
                    Guid firstCompanionId = (Guid)icons.Data.First().Id;
                    accById =new AccountIconViewModelById<AccountIconViewModel>(firstCompanionId);
                    messages = (List<MessageViewModel>)(await _messageService.GetMessagesBetween(accountId, firstCompanionId)).Data;
                    companion=icons.Data.FirstOrDefault();
                }
                var chattingViewModel = new ChattingViewModel()
                {
                    AccountIconInCorrespondenceViewsModels= (List<AccountIconViewModel>)icons.Data,
                    Companion=companion,
                    MessageOfCurrentCorrespondenceViewModels=messages
                };
                return new StandartResponse<ChattingViewModel>()
                {
                    Data = chattingViewModel,
                    StatusCode = StatusCode.ChattingModelCreate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetChattingViewModel] : {ex.Message}");
                return new StandartResponse<ChattingViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
