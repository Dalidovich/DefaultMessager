using DefaultMessager.BLL.Hubs;
using DefaultMessager.BLL.Middleware;
using DefaultMessager.DAL;
using DefaultMessager.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DefaultMessager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton(builder.Configuration);

            builder.Services.AddDbContext<MessagerDbContext>(opt => opt.UseNpgsql(
                builder.Configuration.GetConnectionString(StandartConst.NameConnection)));

            builder.AddRepositores();
            builder.AddServices();
            builder.AddJWT();

            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:7150")
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST")
                            .AllowCredentials();
                        builder.WithOrigins("https://localhost:7150")
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST")
                            .AllowCredentials();
                    });
            });

            builder.Services.AddSingleton<ChatManager>();

            var app = builder.Build();
            app.UseCookiePolicy();
            app.UseMiddleware<JWTMiddleware>();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.MapHub<CommunicationCommentHub>("/comment");
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}