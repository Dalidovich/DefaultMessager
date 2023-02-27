using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IAccountService
    {
        public string GetRefreshToken();
        public string GetToken(AccountAuthenticateViewModel account);
        public Task<BaseResponse<AccountProfileViewModel>> GetProfile(Expression<Func<AccountProfileViewModel, bool>> expression);
        public Task<BaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId, string refreshTokenStr);
        public Task<BaseResponse<(string, string, Guid)>> Authenticate(LogInAccountViewModel viewModel, bool forRefresh);
        public Task<BaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel);
    }
}
