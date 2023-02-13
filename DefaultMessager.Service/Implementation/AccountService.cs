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

namespace DefaultMessager.Service.Implementation
{
    public class AccountService<T> : BaseService<T>, IAccountService where T : Account
    {
        private readonly JWTSettings _options;
        public AccountService(IBaseRepository<T> repository, ILogger<T> logger, IOptions<JWTSettings> options) : base(repository, logger)
        {
            _options = options.Value;
        }
        public async Task<IBaseResponse<RefreshToken>> Registration(RegisterAccountViewModel viewModel)
        {
            try
            {
                var accountOnRegistration = await GetOne(x => x.Login == viewModel.Login);
                if (accountOnRegistration.Data != null)
                {
                    return new BaseResponse<RefreshToken>()
                    {
                        Description = "Account with that login alredy exist"
                    };
                }
                var newAccount = new Account(viewModel);
                newAccount = await _repository.createAsync((T)newAccount);
                return new BaseResponse<RefreshToken>()
                {
                    Data = (await Authenticate(new LogInAccountViewModel(newAccount))).Data,
                    StatusCode = StatusCode.AccountCreate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Registration] : {ex.Message}");
                return new BaseResponse<RefreshToken>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public async Task<IBaseResponse<RefreshToken>> Authenticate(LogInAccountViewModel viewModel)
        {
            try
            {
                var account = (await GetOne(x => x.Login == viewModel.Login&& x.Password== viewModel.Password)).Data;
                if (account == null)
                {
                    return new BaseResponse<RefreshToken>()
                    {
                        Description = "account not found"
                    };
                }
                string token = GetToken(account);
                var refreshToken = GetRefreshToken();
                return new BaseResponse<RefreshToken>()
                {
                    Data=refreshToken,
                    StatusCode = StatusCode.AccountAuthenticate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Authenticate] : {ex.Message}");
                return new BaseResponse<RefreshToken>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        public string GetToken(Account account)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Login));
            claims.Add(new Claim("Хэш пароля", $"{account.Password}"));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        private RefreshToken GetRefreshToken()
        {
            RefreshToken refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }
    }
}
