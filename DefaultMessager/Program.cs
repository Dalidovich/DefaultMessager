using DefaultMessager.DAL;
using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories;
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

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton(builder.Configuration);

            MessagerDbContext.ConnectionString = builder.Configuration["ConnectionStrings"];

            //DbContextOptions<MessagerDbContext> dbContextOptions = new DbContextOptions<MessagerDbContext>();
            //DbContextOptionsBuilder<MessagerDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<MessagerDbContext>().UseNpgsql(
            //    MessagerDbContext.ConnectionString);
            //MessagerDbContext appDBContext = new MessagerDbContext();
            //appDBContext.UpdateDatabase();
            
            builder.Services.AddDbContext<MessagerDbContext>(opt => opt.UseNpgsql(MessagerDbContext.ConnectionString));

            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IDescriptionUserRepository, DescriptionUserRepository>();
            builder.Services.AddScoped<IImageAlbumRepository, ImageAlbumRepository>();
            builder.Services.AddScoped<ILikeRepository, LikeRepository>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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