using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DefaultMessager.DAL
{
    public partial class MessagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DescriptionUser> DescriptionUsers { get; set; }
        public DbSet<ImageAlbum> ImageAlbums { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public void CreateDatabase() => Database.EnsureCreated();
        public void DropDatabase() => Database.EnsureDeleted();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;port=5432;Database=my_db;Username=postgres;Password=pGJRF54321");
        public MessagerDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}