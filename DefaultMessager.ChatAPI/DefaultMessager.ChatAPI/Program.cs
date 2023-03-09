
using DefaultMessager.ChatAPI.Hubs;

namespace DefaultMessager.ChatAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7150")
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST")
                            .AllowCredentials();
                    });
            });

            builder.Services.AddSingleton<ChatManager>();

            var app = builder.Build();

            app.UseCors();
            app.UseHttpsRedirection();
            app.MapHub<CommunicationCommentHub>("/comment");

            app.Run();
        }
    }
}