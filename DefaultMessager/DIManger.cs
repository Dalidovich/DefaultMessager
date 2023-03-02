using DefaultMessager.BLL.Implementation;
using DefaultMessager.BLL.Interfaces;
using DefaultMessager.DAL.BackblazeS3;
using DefaultMessager.DAL.BackblazeS3.ClientProvider;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories;
using DefaultMessager.DAL.Repositories.AccountRepositores;
using DefaultMessager.DAL.Repositories.CommentRepositories;
using DefaultMessager.DAL.Repositories.PostRepositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DefaultMessager
{
    public static class DIManger
    {
        public static void AddRepositores(this WebApplicationBuilder webApplicationBuilder)
        {
           
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Comment>, CommentRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<DescriptionAccount>, DescriptionAccountRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<ImageAlbum>, ImageAlbumRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Like>, LikeRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Message>, MessageRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Post>, PostRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Account>, AccountRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<RefreshToken>, RefreshTokenRepository>();

            webApplicationBuilder.Services.AddScoped<AccountNavRepository>();
            webApplicationBuilder.Services.AddScoped<PostNavRepository>();
            webApplicationBuilder.Services.AddScoped<CommentNavRepositories>();
        }

        public static void AddServices(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<CommentService<Comment>>();
            webApplicationBuilder.Services.AddScoped<DescriptionAccountService<DescriptionAccount>>();
            webApplicationBuilder.Services.AddScoped<ImageAlbumService<ImageAlbum>>();
            webApplicationBuilder.Services.AddScoped<LikeService<Like>>();
            webApplicationBuilder.Services.AddScoped<MessageService<Message>>();
            webApplicationBuilder.Services.AddScoped<PostService<Post>>();
            webApplicationBuilder.Services.AddScoped<AccountService<Account>>();
            webApplicationBuilder.Services.AddScoped<RefreshTokenService<RefreshToken>>();
            webApplicationBuilder.Services.AddScoped<IRegistrationService,RegistrationService>();

            webApplicationBuilder.Services.Configure<BackblazeClientOptions>(
                webApplicationBuilder.Configuration.GetSection(BackblazeClientOptions.NameSettings)
            );
            webApplicationBuilder.Services.AddScoped<IBackblazeClientProvider, BackblazeClientProvider>();
        }

        public static void AddJWT(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.Configure<JWTSettings>(webApplicationBuilder.Configuration.GetSection("JWTSettings"));
            var secretKey = webApplicationBuilder.Configuration.GetSection("JWTSettings:SecretKey").Value;
            var issuer = webApplicationBuilder.Configuration.GetSection("JWTSettings:Issuer").Value;
            var audience = webApplicationBuilder.Configuration.GetSection("JWTSettings:Audience").Value;
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            webApplicationBuilder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = JwtHelper.CustomLifeTimeValidator
                };
            });
        }
    }
}
