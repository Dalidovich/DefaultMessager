using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.AccountSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Microsoft.Extensions.Logging;

namespace DefaultMessager.BLL.Implementation
{
    public class DescriptionAccountService<T> : BaseService<T>, IDescriptionAccountService where T : DescriptionAccount
    {
        private readonly AccountService<Account> _accountService;
        private readonly IBackblazeClientProvider _BackblazeClientProvider;
        public DescriptionAccountService(IBaseRepository<T> repository, ILogger<T> logger, AccountService<Account> accountService
            ,IBackblazeClientProvider backblazeClientProvider) : base(repository, logger)
        {
            _accountService = accountService;
            _BackblazeClientProvider= backblazeClientProvider;
        }

        public async Task<BaseResponse<bool>> updateAvatarPath(string login, MemoryStream content)
        {
            try
            {
                var client = await _BackblazeClientProvider.GetClient();
                var accountAuthByLogin = new AccountAuthByLogin<AccountAuthenticateViewModel>(login);
                var fileId = await client.UploadObjectFromStreamAsync(_accountService.GetAccountBucket(login).Data, login + @"/avatar.png", content);
                var response = await _accountService.GetAccountIncludeDescribeAndRefreshToken(accountAuthByLogin.ToExpression());
                response.Data.Description.PathAvatar = client.GetFileLink(fileId);
                await Update((T)response.Data.Description);
                return new StandartResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.FileUpload
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetOne] : {ex.Message}");
                return new StandartResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
