using DefaultMessager.DAL.Interfaces;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using DefaultMessager.DAL.Repositories.AccountRepositores;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.BLL.Base;
using DefaultMessager.Domain.SpecificationPattern.CustomSpecification.AccountSpecification;

namespace DefaultMessager.BLL.Implementation
{
    public class AccountService<T> : BaseService<T>, IAccountService where T : Account
    {
        private readonly JWTSettings _options;
        private readonly DescriptionAccountService<DescriptionAccount> _descriptionAccountService;
        private readonly RefreshTokenService<RefreshToken> _refreshTokenService;
        private readonly AccountNavRepository _navAccountRepository;
        public AccountService(IBaseRepository<T> repository, ILogger<T> logger, IOptions<JWTSettings> options
            , DescriptionAccountService<DescriptionAccount> descriptionAccountService
            , RefreshTokenService<RefreshToken> refreshTokenService, AccountNavRepository navAccountRepository) : base(repository, logger)
        {
            _options = options.Value;
            _descriptionAccountService = descriptionAccountService;
            _refreshTokenService = refreshTokenService;
            _navAccountRepository = navAccountRepository;
            _navAccountRepository = navAccountRepository;
        }
        public async Task<IBaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel)
        {
            try
            {
                var accountOnRegistration = (await GetOne(x => x.Login == viewModel.Login)).Data;
                if (accountOnRegistration != null)
                {
                    return new BaseResponse<(string, string, Guid)>()
                    {
                        Description = "Account with that login alredy exist"
                    };
                }
                CreatePasswordHash(viewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var newAccount = new Account(viewModel, Convert.ToBase64String(passwordSalt), Convert.ToBase64String(passwordHash));
                newAccount = await _repository.createAsync((T)newAccount);
                await _descriptionAccountService.Create(new DescriptionAccount((Guid)newAccount.Id, "/img/cover 1.png"));
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
        public async Task<IBaseResponse<(string, string, Guid)>> Authenticate(LogInAccountViewModel viewModel, bool forRefresh = false)
        {
            try
            {
                var accountByLogin = new AccountAuthByLogin<Account>(viewModel.Login);
                var account = _navAccountRepository.GetIncludeDescribeAndRefreshToken(accountByLogin.ToExpression()).FirstOrDefault();
                if (account == null || !VerifyPasswordHash(viewModel.Password, Convert.FromBase64String(account.Password), Convert.FromBase64String(account.Salt)))
                {
                    if (!forRefresh && account != null)
                    {
                        return new BaseResponse<(string, string, Guid)>()
                        {
                            Description = "account not found"
                        };
                    }
                }
                string token = GetToken(account, account.Description.PathAvatar);
                var refreshTokenStr = GetRefreshToken();
                account.RefreshToken.Token = refreshTokenStr;
                await _refreshTokenService.Update(account.RefreshToken);
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
        public async Task<IBaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId, string refreshTokenStr)
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
                    Data = (await Authenticate(viewModel, true)).Data,
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
        public string GetToken(AccountAuthenticateViewModel account, string pathAvatar)
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
            var refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            return refreshToken;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string Password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
