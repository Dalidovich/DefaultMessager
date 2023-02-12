using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DefaultMessager.DAL
{
    public partial class MessagerDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DescriptionAccount> DescriptionAccounts { get; set; }
        public DbSet<ImageAlbum> ImageAlbums { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Relations> Relations { get; set; }
        public static string ConnectionString { get; set; }

        public void UpdateDatabase()
        {
            Database.EnsureDeleted();
            Database.Migrate();
            standartFill();
        }
        private void standartFill()
        {
            var account = new Account("email_1", "123", "Ilia", Role.admin, DateTime.Now, StatusAccount.normal);
            this.Accounts.Add(account);
            this.SaveChanges();
            List<Post> posts = new List<Post>();
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 2", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 3", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 4", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 1", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 5", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 6", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            posts.Add(new Post((Guid)account.Id, new[] { "/img/cover 1.png" }, "text1", "post 7", new[] { "none" }, DateTime.Now));
            this.Posts.AddRange(posts);
            this.SaveChanges();
        }
        public MessagerDbContext(DbContextOptions<MessagerDbContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(ConnectionString);
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