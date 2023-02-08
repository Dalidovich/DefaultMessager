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

            builder.Services.AddScoped<IBaseRepository<Comment>, CommentRepository>();
            builder.Services.AddScoped<IBaseRepository<DescriptionUser>, DescriptionUserRepository>();
            builder.Services.AddScoped<IBaseRepository<ImageAlbum>, ImageAlbumRepository>();
            builder.Services.AddScoped<IBaseRepository<Like>, LikeRepository>();
            builder.Services.AddScoped<IBaseRepository<Message>, MessageRepository>();
            builder.Services.AddScoped<IBaseRepository<Post>, PostRepository>();
            builder.Services.AddScoped<IBaseRepository<User>, UserRepository>();

            builder.Services.AddScoped<CommentService<Comment>>();
            builder.Services.AddScoped<DescriptionUserService<DescriptionUser>>();
            builder.Services.AddScoped<ImageAlbumService<ImageAlbum>>();
            builder.Services.AddScoped<LikeService<Like>>();
            builder.Services.AddScoped<MessageService<Message>>();
            builder.Services.AddScoped<PostService<Post>>();
            builder.Services.AddScoped<UserService<User>>();


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