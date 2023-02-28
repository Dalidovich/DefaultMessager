using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IAccountService
    {
        public Task<BaseResponse<AccountProfileViewModel>> GetProfile(Expression<Func<AccountProfileViewModel, bool>> expression);
        public Task<BaseResponse<AccountAuthenticateViewModel>> GetAccountIncludeDescribeAndRefreshToken(Expression<Func<AccountAuthenticateViewModel, bool>> expression);
        public BaseResponse<string> GetAccountBucket(string login);
    }
}
