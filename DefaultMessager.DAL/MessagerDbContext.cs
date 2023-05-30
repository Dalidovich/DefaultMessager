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
            string[] postImage = new string[]
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
                "https://avavatar.ru/images/avatars/6/avatar_4JxC6qW2ZNWhoDP3.jpg"
            };

            string[] iconImage = new string[]
            {
                "https://avavatar.ru/images/avatars/25/avatar_wDBp3hJ1IOgLM4lp.jpg",
                "https://avavatar.ru/images/avatars/21/avatar_aWL38thg6bH5qwZ4.jpg",
                "https://avavatar.ru/images/avatars/17/avatar_ejRxZa73N4192wY8.jpg",
                "https://avavatar.ru/images/avatars/9/avatar_7jd8Ligk6wvepzEO.jpg",
                "https://avavatar.ru/images/avatars/16/avatar_c8OqOxcZ0Hc56Pa3.jpg",
                "https://avavatar.ru/images/avatars/5/avatar_03OvNBA78PdLOebH.jpg",
                "https://avavatar.ru/images/avatars/8/avatar_GmPXcrnYGVrf78CP.jpg",
                "https://avavatar.ru/images/avatars/8/avatar_u6Jo7F870W3Xy7ym.jpg",
                "https://avavatar.ru/images/avatars/13/avatar_JCWSZ0Mhb2YBxXNo.jpg",
                "https://avavatar.ru/images/avatars/17/avatar_VCCPQs5nVRo2aqtW.jpg",
                "https://avavatar.ru/images/avatars/18/avatar_wk8tKH7R62yAfGRV.jpg",
                "https://avavatar.ru/images/avatars/21/avatar_pFC2Ki8yn2Bri4rl.jpg",
                "https://avavatar.ru/images/avatars/21/avatar_pFC2Ki8yn2Bri4rl.jpg",
                "https://avavatar.ru/images/avatars/22/avatar_ggjSpZwtBMx3pRjj.jpg",
                "https://avavatar.ru/images/avatars/24/avatar_Qp5E4sboDoxhowoM.jpg",
                "https://avavatar.ru/images/avatars/26/avatar_xuwixSlUGCuX6FrM.jpg",
                "https://avavatar.ru/images/avatars/5/avatar_D6QgLQo6xUbaRkr2.jpg",
                "https://avavatar.ru/images/avatars/5/avatar_lw93hHtyylINZMWK.jpg",
                "https://avavatar.ru/images/avatars/10/avatar_ldicWSN511qTWquK.jpg",
                "https://avavatar.ru/images/avatars/13/avatar_XA1ImrFRiQr5fjBl.jpg",
                "https://avavatar.ru/images/avatars/13/avatar_bv3zD6emcrRkixcC.jpg",
                "https://avavatar.ru/images/avatars/14/avatar_OZriuQ4WTHDjqIXw.jpg",
                "https://avavatar.ru/images/avatars/45/avatar_FAD3lVTFD47Iiu4d.jpg",
                "https://avavatar.ru/images/avatars/15/avatar_EfIzbpvfqqtMTlCy.jpg",
                "https://avavatar.ru/images/avatars/17/avatar_JejGABjYW5LUKYmH.jpg",
                "https://avavatar.ru/images/avatars/17/avatar_plc5PiTa7Vprrr1C.jpg",
            };

            string[] usernames = new string[]
            { 
                "Alice",
                "Bob",
                "Charlie",
                "Dave",
                "Emily",
                "Frank",
                "Grace",
                "Hannah",
                "Isaac",
                "Jessica",
                "Kevin",
                "Liam",
                "Molly",
                "Nora",
                "Oliver",
                "Penny",
                "Quincy",
                "Rachel",
                "Samuel",
                "Tom",
                "Ursula",
                "Victoria",
                "Wendy",
                "Xavier",
                "Yara",
                "Zack"
            };

            string[] englishWords = { "apple", "banana", "car", "dog", "elephant", "frog", "guitar", "house", "ice cream", "jacket", "kangaroo", "lion", "map", "notebook", "orange", "piano", "queen", "rain", "snake", "tree", "umbrella", "violin", "watermelon", "xylophone", "yacht", "zebra" };

            int countFill = postImage.Length;
            List<Account> accounts = new List<Account>();
            for (int i = 0; i < countFill; i++)
            {
                accounts.Add(new Account("email_1", usernames[i], "456", Role.admin, DateTime.Now, StatusAccount.normal));
            }
            this.Accounts.AddRange(accounts);
            this.SaveChanges();

            List<DescriptionAccount> descriptionAccounts = new List<DescriptionAccount>();
            for (int i = 0; i < countFill; i++)
            {
                descriptionAccounts.Add(new DescriptionAccount((Guid)accounts[i].Id, iconImage[i]));
            };
            this.DescriptionAccounts.AddRange(descriptionAccounts);
            this.SaveChanges();
            Random random = new Random();
            List<Post> posts = new List<Post>();
            for (int i = 0; i < countFill; i++)
            {
                posts.Add(new Post((Guid)accounts[i].Id, new[] { postImage[i] }, englishWords[i], "post " + i.ToString(), new[] { "none" }, DateTime.Now));
            }
            this.Posts.AddRange(posts);
            this.SaveChanges();
            List<ImageAlbum> albums = new List<ImageAlbum>();
            List<string> photos = new List<string>();
            for (int k = countFill-1; k >-1 ; k--)
            {
                photos.Add(postImage[k]);
            }
            albums.Add(new ImageAlbum((Guid)accounts[0].Id, photos.ToArray(), $"title{0}"));
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