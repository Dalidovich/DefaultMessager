using DefaultMessager.DAL;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;
using DefaultMessager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DefaultMessager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton(builder.Configuration);

            MessagerDbContext.ConnectionString = builder.Configuration["ConnectionStrings"];

            //DbContextOptions<MessagerDbContext> dbContextOptions = new DbContextOptions<MessagerDbContext>();
            //DbContextOptionsBuilder<MessagerDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<MessagerDbContext>().UseNpgsql(
            //    MessagerDbContext.ConnectionString);
            //MessagerDbContext appDBContext = new MessagerDbContext();
            //appDBContext.UpdateDatabase();
            
            builder.Services.AddDbContext<MessagerDbContext>(opt => opt.UseNpgsql(MessagerDbContext.ConnectionString));

            builder.addRepositores();
            builder.addServices();


            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}