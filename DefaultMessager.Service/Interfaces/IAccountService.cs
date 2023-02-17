using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using System.Linq.Expressions;

namespace DefaultMessager.Service.Interfaces
{
    public interface IAccountService
    {
        public string GetRefreshToken();
        public string GetToken(Account account, string pathAvatar);
        public Task<IBaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId, string refreshTokenStr);
        public Task<IBaseResponse<(string, string, Guid)>> Authenticate(LogInAccountViewModel viewModel,bool forRefresh);
        public Task<IBaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel);
    }
}
