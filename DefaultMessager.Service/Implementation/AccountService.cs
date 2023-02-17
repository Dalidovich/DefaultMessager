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
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.RefreshTokenSpecification;
using System.Security.Principal;

namespace DefaultMessager.Service.Implementation
{
    public class AccountService<T> : BaseService<T>, IAccountService where T : Account
    {
        private readonly JWTSettings _options;
        private readonly DescriptionAccountService<DescriptionAccount> _descriptionAccountService;
        private readonly RefreshTokenService<RefreshToken> _refreshTokenService;
        public AccountService(IBaseRepository<T> repository, ILogger<T> logger, IOptions<JWTSettings> options
            , DescriptionAccountService<DescriptionAccount> descriptionAccountService, RefreshTokenService<RefreshToken> refreshTokenService) : base(repository, logger)
        {
            _options = options.Value;
            _descriptionAccountService = descriptionAccountService;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<IBaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel)
        {
            try
            {
                string a = viewModel.Password;
                var accountOnRegistration = await GetOne(x => x.Login == viewModel.Login);
                if (accountOnRegistration.Data != null)
                {
                    return new BaseResponse<(string, string, Guid)>()
                    {
                        Description = "Account with that login alredy exist"
                    };
                }
                CreatePasswordHash(viewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var newAccount = new Account(viewModel, Convert.ToBase64String(passwordSalt), Convert.ToBase64String(passwordHash));
                newAccount = await _repository.createAsync((T)newAccount);
                var newDescriptionAccount = new DescriptionAccount((Guid)newAccount.Id, "/img/cover 1.png");
                await _descriptionAccountService.Create(newDescriptionAccount);
                await _refreshTokenService.Create(new RefreshToken((Guid)newAccount.Id, "none"));
                return new BaseResponse<(string, string, Guid)>()
                {
                    Data = (await Authenticate(new LogInAccountViewModel(viewModel))).Data,
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
        public async Task<IBaseResponse<(string,string,Guid)>> Authenticate(LogInAccountViewModel viewModel,bool forRefresh=false)
        {
            try
            {
                var account = (await GetOne(x => x.Login == viewModel.Login)).Data;
                if (account == null||!VerifyPasswordHash(viewModel.Password,Convert.FromBase64String(account.Password),Convert.FromBase64String(account.Salt)))
                {
                    if (!forRefresh)
                    {
                        return new BaseResponse<(string, string, Guid)>()
                        {
                            Description = "account not found"
                        };
                    }
                }
                var descriptionByAccountId = new DescriptionAccountByAccountId<DescriptionAccount>((Guid)account.Id);
                var description = (await _descriptionAccountService.GetOne(descriptionByAccountId.ToExpression())).Data;
                string token = GetToken(account,description.PathAvatar);
                var refreshTokenStr = GetRefreshToken();
                var refreshTokenByAccountId = new RefreshTokenByAccountId<RefreshToken>((Guid)account.Id);
                var refreshToken = (await _refreshTokenService.GetOne(refreshTokenByAccountId.ToExpression())).Data;
                refreshToken.Token = refreshTokenStr;
                await _refreshTokenService.Update(refreshToken);
                return new BaseResponse<(string, string, Guid)>()
                {
                    Data = (token, refreshTokenStr, (Guid)account.Id),
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
                var refreshToken = (await _refreshTokenService.GetOne(x => x.AccountId == accountId && x.Token == refreshTokenStr)).Data;
                if (refreshToken == null)
                {
                    return new BaseResponse<(string, string, Guid)>()
                    {
                        Description = "token not found"
                    };
                }

                var account = (await GetOne(x => x.Id == accountId)).Data;
                LogInAccountViewModel viewModel = new LogInAccountViewModel(account);
                return new BaseResponse<(string, string, Guid)>()
                {
                    Data = (await Authenticate(viewModel,true)).Data,
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
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string Password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
