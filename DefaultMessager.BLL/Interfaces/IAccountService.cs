using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IAccountService
    {
        public string GetRefreshToken();
        public string GetToken(AccountAuthenticateViewModel account, string pathAvatar);
        public Task<IBaseResponse<AccountProfileViewModel>> GetProfile(Expression<Func<AccountProfileViewModel, bool>> expression);
        public Task<IBaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId, string refreshTokenStr);
        public Task<IBaseResponse<(string, string, Guid)>> Authenticate(LogInAccountViewModel viewModel, bool forRefresh);
        public Task<IBaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel);
    }
}
