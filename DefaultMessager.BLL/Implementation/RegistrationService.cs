using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using DefaultMessager.Domain.JWT;
using DefaultMessager.Domain.Response.Base;
using DefaultMessager.Domain.Specification.CustomSpecification.AccountSpecification;
using DefaultMessager.Domain.ViewModel.AccountModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DefaultMessager.BLL.Implementation
{
    public class RegistrationService: IRegistrationService
    {
        protected readonly ILogger<Account> _logger;
        private readonly JWTSettings _options;
        private readonly DescriptionAccountService<DescriptionAccount> _descriptionAccountService;
        private readonly RefreshTokenService<RefreshToken> _refreshTokenService;
        private readonly AccountService<Account> _accountService;
        private readonly IBackblazeClientProvider _BackblazeClientProvider;

        public RegistrationService(IOptions<JWTSettings> options, DescriptionAccountService<DescriptionAccount> descriptionAccountService
            , RefreshTokenService<RefreshToken> refreshTokenService, IBackblazeClientProvider backblazeClientProvider
            ,AccountService<Account> accountService,ILogger<Account> logger)
        {
            _options = options.Value;
            _descriptionAccountService = descriptionAccountService;
            _refreshTokenService = refreshTokenService;
            _BackblazeClientProvider = backblazeClientProvider;
            _accountService = accountService;
            _logger = logger;
        }

        public async Task<BaseResponse<(string, string, Guid)>> Registration(RegisterAccountViewModel viewModel)
        {
            try
            {
                var accountOnRegistration = (await _accountService.GetOne(x => x.Login == viewModel.Login)).Data;
                if (accountOnRegistration != null)
                {
                    return new StandartResponse<(string, string, Guid)>()
                    {
                        Description = "Account with that login alredy exist"
                    };
                }
                CreatePasswordHash(viewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var newAccount = new Account(viewModel, Convert.ToBase64String(passwordSalt), Convert.ToBase64String(passwordHash));
                newAccount = (await _accountService.Add(newAccount)).Data;
                try
                {
                    var client = await _BackblazeClientProvider.GetClient();
                    var avatarLink = await client.GetFileLink(StandartConst.StandartBucketName, @"standartAvatar.png");
                    await _descriptionAccountService.Add(new DescriptionAccount((Guid)newAccount.Id, avatarLink));
                    await _refreshTokenService.Add(new RefreshToken((Guid)newAccount.Id, "none"));
                    return new StandartResponse<(string, string, Guid)>()
                    {
                        Data = (await Authenticate(new LogInAccountViewModel(viewModel))).Data,
                        StatusCode = StatusCode.AccountCreate
                    };
                }
                catch (Exception)
                {
                    await _accountService.Delete(x => x.Id == newAccount.Id);
                    throw;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Registration] : {ex.Message}");
                return new StandartResponse<(string, string, Guid)>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<(string, string, Guid)>> Authenticate(LogInAccountViewModel viewModel, bool forRefresh = false)
        {
            try
            {
                var accountByLogin = new AccountAuthByLogin<AccountAuthenticateViewModel>(viewModel.Login);
                var account = await _accountService.GetAccountIncludeDescribeAndRefreshToken(accountByLogin.ToExpression());
                if (account.Data == null || !VerifyPasswordHash(viewModel.Password, Convert.FromBase64String(account.Data.Password), Convert.FromBase64String(account.Data.Salt)))
                {
                    if ((!forRefresh) && account.Data == null)
                    {
                        return new StandartResponse<(string, string, Guid)>()
                        {
                            Description = "account not found"
                        };
                    }
                }
                string token = GetToken(account.Data);
                var refreshTokenStr = GetRefreshToken();
                account.Data.RefreshToken.Token = refreshTokenStr;
                await _refreshTokenService.Update(account.Data.RefreshToken);
                return new StandartResponse<(string, string, Guid)>()
                {
                    Data = (token, refreshTokenStr, (Guid)(account.Data.Id)),
                    StatusCode = StatusCode.AccountAuthenticate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Authenticate] : {ex.Message}");
                return new StandartResponse<(string, string, Guid)>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<BaseResponse<(string, string, Guid)>> RefreshJWTToken(Guid accountId, string refreshTokenStr)
        {
            try
            {
                var refreshToken = (await _refreshTokenService.GetOne(x => x.AccountId == accountId && x.Token == refreshTokenStr)).Data;
                if (refreshToken == null)
                {
                    return new StandartResponse<(string, string, Guid)>()
                    {
                        Description = "token not found"
                    };
                }
                var account = (await _accountService.GetOne(x => x.Id == accountId)).Data;
                LogInAccountViewModel viewModel = new LogInAccountViewModel(account);
                return new StandartResponse<(string, string, Guid)>()
                {
                    Data = (await Authenticate(viewModel, true)).Data,
                    StatusCode = StatusCode.AccountAuthenticate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[RefreshJWTToken] : {ex.Message}");
                return new StandartResponse<(string, string, Guid)>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public string GetToken(AccountAuthenticateViewModel account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Login),
                new Claim(ClaimTypes.Role, account.Role.ToString()),
                new Claim(CustomClaimType.AccountId, account.Id.ToString()),
                new Claim(CustomClaimType.AccountPathAvatar, account.Description.PathAvatar)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

            var jwt = new JwtSecurityToken(
                    issuer: _options.Issuer,
                    audience: _options.Audience,
                    claims: claims,
                    expires: DateTime.Now.Add(TimeSpan.FromMinutes(StandartConst.StartJWTTokenLifeTime)),
                    notBefore: DateTime.Now,
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
