using DefaultMessager.BLL.Middleware;
using DefaultMessager.DAL;
using DefaultMessager.DAL.Connection;
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

            builder.Services.AddDbContext<MessagerDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString(StandartConst.NameConnection)));

            builder.AddRepositores();
            builder.AddServices();
            builder.AddJWT();
            /*
                        DbContextOptionsBuilder<MessagerDbContext> t = new DbContextOptionsBuilder<MessagerDbContext>();
                        MessagerDbContext dbContext = new MessagerDbContext(t, builder.Configuration.GetConnectionString(NpgConnectionOptions.NameConnection));
                        dbContext.UpdateDatabase();*/



            var app = builder.Build();


/*                var context = app.Services.GetRequiredService<MessagerDbContext>();
            context.UpdateDatabase();*/

            app.UseCookiePolicy();
            app.UseMiddleware<JWTMiddleware>();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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