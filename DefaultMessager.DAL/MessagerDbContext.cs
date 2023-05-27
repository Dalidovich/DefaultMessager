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
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public void UpdateDatabase()
        {
            Database.EnsureDeleted();
            Database.Migrate();
            StandartFill();

            Console.WriteLine("____________________________________________________");
            Console.WriteLine("reload");
            Console.WriteLine("____________________________________________________");
        }

        private void StandartFill()
        {
            string[] images = new string[]
            {
                "https://www.w3schools.com/w3images/fjords.jpg",
                "https://www.w3schools.com/w3images/rocks.jpg",
                "https://www.w3schools.com/w3images/lights.jpg",
                "https://www.w3schools.com/w3images/nature.jpg",
                "https://www.w3schools.com/w3images/mountains.jpg",
                "https://www.w3schools.com/w3images/forest.jpg",
                "https://avavatar.ru/images/avatars/21/avatar_WOETp5TLwXTdgLcg.jpg",
                "https://avavatar.ru/images/avatars/20/avatar_wVqHRFAuOeDDajWc.jpg",
                "https://avavatar.ru/images/avatars/28/avatar_jUAJBQpnoIhZoKbV.jpg",
                "https://www.w3schools.com/w3images/paris.jpg",
                "https://www.w3schools.com/w3images/newyork.jpg",
                "https://www.w3schools.com/w3images/sanfran.jpg",
                "https://www.w3schools.com/w3images/wedding.jpg",
                "https://www.w3schools.com/w3images/p3.jpg",
                "https://www.w3schools.com/w3images/p4.jpg",
                "https://www.w3schools.com/w3images/p5.jpg",
                "https://www.w3schools.com/w3images/underwater.jpg",
                "https://www.w3schools.com/w3images/p6.jpg",
                "https://www.w3schools.com/w3images/p7.jpg",
                "https://www.w3schools.com/w3images/coffee.jpg",
                "https://www.w3schools.com/w3images/p8.jpg",
                "https://avavatar.ru/images/avatars/4/avatar_7hRoFoCmwzVxVuMh.jpg",
                "https://www.w3schools.com/w3images/p1.jpg",
                "https://www.w3schools.com/w3images/p2.jpg",
                "https://avavatar.ru/images/avatars/7/avatar_eYjGUfegeuEhbgWf.jpg",
                "https://avavatar.ru/images/avatars/6/avatar_4JxC6qW2ZNWhoDP3.jpg",
                
            };

            int countFill = images.Length;
            List<Account> accounts = new List<Account>();
            for (int i = 0; i < countFill; i++)
            {
                accounts.Add(new Account("email_1", i.ToString(), "456", Role.admin, DateTime.Now, StatusAccount.normal));
            }
            this.Accounts.AddRange(accounts);
            this.SaveChanges();

            List<DescriptionAccount> descriptionAccounts = new List<DescriptionAccount>();
            for (int i = 0; i < countFill; i++)
            {
                descriptionAccounts.Add(new DescriptionAccount((Guid)accounts[i].Id, images[i]));
            };
            this.DescriptionAccounts.AddRange(descriptionAccounts);
            this.SaveChanges();
            Random random = new Random();
            List<Post> posts = new List<Post>();
            for (int i = 0; i < countFill; i++)
            {
                posts.Add(new Post((Guid)accounts[i].Id, new[] { images[i] }, "text1", "post " + i.ToString(), new[] { "none" }, DateTime.Now));
            }
            this.Posts.AddRange(posts);
            this.SaveChanges();
            List<ImageAlbum> albums = new List<ImageAlbum>();
            for (int i = 0; i < countFill; i++)
            {
                List<string> photos=new List<string>();
                for (int k = 0; k < countFill; k++)
                {
                    photos.Add(StandartPath.defaultAvatarImage);
                }
                albums.Add(new ImageAlbum((Guid)accounts[0].Id, photos.ToArray(), $"title{i}"));
            }
            this.ImageAlbums.AddRange(albums);
            this.SaveChanges();
            List<Comment> comments = new List<Comment>();
            for (int i = 0; i < countFill; i++)
            {
                for (int k = 0; k < countFill; k++)
                {
                    comments.Add(new Comment((Guid)posts[i].Id, (Guid)accounts[i].Id, (k + 1).ToString(), DateTime.Now, StatusComment.normal));
                }
            }
            this.Comments.AddRange(comments);
            this.SaveChanges();
        }

        public MessagerDbContext(DbContextOptions<MessagerDbContext> options) : base(options) 
        {
        }

        public MessagerDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(optionsBuilder.Options.ToString());
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