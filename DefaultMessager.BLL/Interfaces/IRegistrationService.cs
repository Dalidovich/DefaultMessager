using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;

namespace DefaultMessager.BLL.Interfaces
{
    public interface IRegistrationService
    {
        public string GetRefreshToken();
        public string GetToken(AccountAuthenticateViewModel account);
        public Task<BaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId, string refreshTokenStr);
        public Task<BaseResponse<(string, string, Guid)>> Authenticate(LogInAccountViewModel viewModel, bool forRefresh = false);
        public Task<BaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel);
    }
}