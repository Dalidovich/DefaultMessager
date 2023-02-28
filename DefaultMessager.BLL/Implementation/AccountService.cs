using DefaultMessager.BLL.Base;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories.AccountRepositores;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Implementation
{
    public class AccountService<T> : BaseService<T>, IAccountService where T : Account
    {
        private readonly AccountNavRepository _navAccountRepository;
        public AccountService(IBaseRepository<T> repository, ILogger<T> logger,AccountNavRepository navAccountRepository) : base(repository, logger)
        {
            _navAccountRepository = navAccountRepository;
        }
        public BaseResponse<string> GetAccountBucket(string login)
        {
            return new StandartResponse<string>()
            {
                Data = "Messager" + ((byte)login.Last()) % 2
            };
        }
        public async Task<BaseResponse<AccountProfileViewModel>> GetProfile(Expression<Func<AccountProfileViewModel, bool>> expression)
        {
            try
            {
                var entity = await _navAccountRepository.GetProfiles(expression).SingleOrDefaultAsync();
                if (entity == null)
                {
                    return new StandartResponse<AccountProfileViewModel>()
                    {
                        Description = "entity not found"
                    };
                }
                return new StandartResponse<AccountProfileViewModel>()
                {
                    Data = entity,
                    StatusCode = StatusCode.AccountRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetOne] : {ex.Message}");
                return new StandartResponse<AccountProfileViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public async Task<BaseResponse<AccountAuthenticateViewModel>> GetAccountIncludeDescribeAndRefreshToken(Expression<Func<AccountAuthenticateViewModel, bool>> expression)
        {
            try
            {
                var entity = await _navAccountRepository.GetIncludeDescribeAndRefreshToken(expression).SingleOrDefaultAsync();
                if (entity == null)
                {
                    return new StandartResponse<AccountAuthenticateViewModel>()
                    {
                        Description = "entity not found"
                    };
                }
                return new StandartResponse<AccountAuthenticateViewModel>()
                {
                    Data = entity,
                    StatusCode = StatusCode.AccountRead
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[GetAccountIncludeDescribeAndRefreshToken] : {ex.Message}");
                return new StandartResponse<AccountAuthenticateViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
    }
}
