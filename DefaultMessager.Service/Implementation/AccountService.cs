using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using DefaultMessager.Service.Base;
using DefaultMessager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.DescriptionUserSpecification;

namespace DefaultMessager.Service.Implementation
{
    public class AccountService<T> : BaseService<T>, IAccountService where T : Account
    {
        private readonly JWTSettings _options;
        private readonly IBaseRepository<DescriptionAccount> _descriptionAccountRepository;
        public AccountService(IBaseRepository<T> repository, ILogger<T> logger, IOptions<JWTSettings> options
            , IBaseRepository<DescriptionAccount> descriptionAccountRepository) : base(repository, logger)
        {
            _options = options.Value;
            _descriptionAccountRepository = descriptionAccountRepository;
        }
        public async Task<IBaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel)
        {
            try
            {
                var accountOnRegistration = await GetOne(x => x.Login == viewModel.Login);
                if (accountOnRegistration.Data != null)
                {
                    return new BaseResponse<(string, string, Guid)>()
                    {
                        Description = "Account with that login alredy exist"
                    };
                }
                var newAccount = new Account(viewModel);
                newAccount = await _repository.createAsync((T)newAccount);
                var newDescriptionAccount = new DescriptionAccount((Guid)newAccount.Id, "/img/cover 1.png");
                await _descriptionAccountRepository.createAsync(newDescriptionAccount);
                return new BaseResponse<(string, string, Guid)>()
                {
                    Data = (await Authenticate(new LogInAccountViewModel(newAccount))).Data,
                    StatusCode = StatusCode.AccountCreate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Registration] : {ex.Message}");
                return new BaseResponse<(string, string, Guid)>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public async Task<IBaseResponse<(string,string,Guid)>> Authenticate(LogInAccountViewModel viewModel)
        {
            try
            {
                var account = (await GetOne(x => x.Login == viewModel.Login&& x.Password== viewModel.Password)).Data;
                if (account == null)
                {
                    return new BaseResponse<(string, string, Guid)>()
                    {
                        Description = "account not found"
                    };
                }
                var descriptionByAccountId = new DescriptionAccountByAccountId<DescriptionAccount>((Guid)account.Id);
                var description =await _descriptionAccountRepository.GetAll().Where(descriptionByAccountId.ToExpression()).SingleOrDefaultAsync();
                string token = GetToken(account,description.PathAvatar);
                var refreshToken = GetRefreshToken();
                account.RefreshToken = refreshToken;
                account = (await Update(account)).Data;
                return new BaseResponse<(string, string, Guid)>()
                {
                    Data = (token, refreshToken, (Guid)account.Id),
                    StatusCode = StatusCode.AccountAuthenticate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Authenticate] : {ex.Message}");
                return new BaseResponse<(string, string, Guid)>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public async Task<IBaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId,string refreshTokenStr)
        {
            try
            {
                var account = (await GetOne(x => x.Id==accountId && x.RefreshToken== refreshTokenStr)).Data;
                if (account == null)
                {
                    return new BaseResponse<(string, string, Guid)>()
                    {
                        Description = "account not found"
                    };
                }
                LogInAccountViewModel viewModel= new LogInAccountViewModel(account);
                return new BaseResponse<(string, string, Guid)>()
                {
                    Data = (await Authenticate(viewModel)).Data,
                    StatusCode = StatusCode.AccountAuthenticate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[RefreshJWTToken] : {ex.Message}");
                return new BaseResponse<(string, string, Guid)>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public string GetToken(Account account,string pathAvatar)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Login),
                new Claim(ClaimTypes.Role, account.Role.ToString()),
                new Claim("id", account.Id.ToString()),
                new Claim("pathAvatar", pathAvatar)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(1)),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        public string GetRefreshToken()
        {
            var refreshToken=Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            return refreshToken;
        }
    }
}
