using DefaultMessager.DAL.Interfaces;
using DefaultMessager.DAL.Repositories;
using DefaultMessager.Domain.Entities;
using DefaultMessager.Service.Implementation;

namespace DefaultMessager
{
    public static class DIManger
    {
        public static void addRepositores(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Comment>, CommentRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<DescriptionUser>, DescriptionUserRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<ImageAlbum>, ImageAlbumRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Like>, LikeRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Message>, MessageRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<Post>, PostRepository>();
            webApplicationBuilder.Services.AddScoped<IBaseRepository<User>, UserRepository>();
        }
        public static void addServices(this WebApplicationBuilder webApplicationBuilder)
        {
            webApplicationBuilder.Services.AddScoped<CommentService<Comment>>();
            webApplicationBuilder.Services.AddScoped<DescriptionUserService<DescriptionUser>>();
            webApplicationBuilder.Services.AddScoped<ImageAlbumService<ImageAlbum>>();
            webApplicationBuilder.Services.AddScoped<LikeService<Like>>();
            webApplicationBuilder.Services.AddScoped<MessageService<Message>>();
            webApplicationBuilder.Services.AddScoped<PostService<Post>>();
            webApplicationBuilder.Services.AddScoped<UserService<User>>();
        }
    }
}
