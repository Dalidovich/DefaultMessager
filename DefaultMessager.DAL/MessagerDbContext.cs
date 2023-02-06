using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<User>(entity => {

                entity.HasKey(e => new { e.UserId });

                entity.Property(e => e.UserId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_user_id");

                entity.Property(e => e.Email)
                      .HasColumnType("character varying")
                      .HasColumnName("email");

                entity.Property(e => e.Login)
                      .HasColumnType("character varying")
                      .HasColumnName("login");

                entity.Property(e => e.Password)
                      .HasColumnType("character varying")
                      .HasColumnName("password");

                entity.Property(e => e.Role)
                      .HasColumnType("smallint")
                      .HasColumnName("role");

                entity.Property(e => e.CreateDate)
                      .HasColumnName("create_date");

                entity.Property(e => e.StatusAccount)
                      .HasColumnType("smallint")
                      .HasColumnName("status_account");

                entity.HasMany(d => d.ImageAlbum)
                      .WithOne(p => p.User)
                      .HasPrincipalKey(p => p.UserId)
                      .HasForeignKey(d => d.UserId);

                entity.HasMany(d => d.Posts)
                      .WithOne(p => p.User)
                      .HasPrincipalKey(p => p.UserId)
                      .HasForeignKey(d => d.UserId);

                entity.HasMany(d => d.SendMessages)
                      .WithOne(p => p.Sender)
                      .HasPrincipalKey(p => p.UserId)
                      .HasForeignKey(d => d.SenderId);

                entity.HasMany(d => d.ReciveMessages)
                      .WithOne(p => p.Reciever)
                      .HasPrincipalKey(p => p.UserId)
                      .HasForeignKey(d => d.RecieveId);

                entity.HasMany(d => d.Likes)
                      .WithOne(p => p.User)
                      .HasPrincipalKey(p => p.UserId)
                      .HasForeignKey(d => d.UserId);

                entity.HasMany(d => d.Comments)
                      .WithOne(p => p.User)
                      .HasPrincipalKey(p => p.UserId)
                      .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.Description)
                      .WithOne(p => p.User)
                      .HasPrincipalKey<User>(p => p.UserId)
                      .HasForeignKey<DescriptionUser>(d => d.UserId);
            });

            modelBuilder.Entity<DescriptionUser>().ToTable("Descriptions_users");
            modelBuilder.Entity<DescriptionUser>(entity => {
                entity.HasKey(e => e.DescriptionId);

                entity.Property(e => e.DescriptionId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_description_id");

                entity.Property(e => e.UserId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_user_id");

                entity.Property(e => e.Name)
                      .HasColumnType("character varying")
                      .HasColumnName("name");

                entity.Property(e => e.Surname)
                      .HasColumnType("character varying")
                      .HasColumnName("surname");

                entity.Property(e => e.Patronymic)
                      .HasColumnType("character varying")
                      .HasColumnName("patronymic");

                entity.Property(e => e.Describe)
                      .HasColumnType("character varying")
                      .HasColumnName("describe");

                entity.Property(e => e.UserStatus)
                      .HasColumnType("character varying")
                      .HasColumnName("user_status");

                entity.Property(e => e.PathAvatar)
                      .HasColumnType("character varying")
                      .HasColumnName("path_avatar");
            });

            modelBuilder.Entity<ImageAlbum>().ToTable("Image_albums");
            modelBuilder.Entity<ImageAlbum>(entity => {
                entity.HasKey(e => e.ImageAlbumId);

                entity.Property(e => e.ImageAlbumId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_image_album_id");

                entity.Property(e => e.UserId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_user_id");

                entity.Property(e => e.PathPictures)
                      .HasColumnType("text[]")
                      .HasColumnName("path_pictures");

                entity.Property(e => e.Title)
                      .HasColumnType("character varying")
                      .HasColumnName("title");
            });

            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<Message>(entity => {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_message_id");

                entity.Property(e => e.RecieveId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_recieve_id");

                entity.Property(e => e.SenderId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_sender_id");

                entity.Property(e => e.PathPictures)
                      .HasColumnType("text[]")
                      .HasColumnName("path_pictures");

                entity.Property(e => e.PathAudios)
                      .HasColumnType("text[]")
                      .HasColumnName("path_audios");

                entity.Property(e => e.SendDateTime)
                      .HasColumnName("send_date_time");

                entity.Property(e => e.MessageStatus)
                      .HasColumnType("smallint")
                      .HasColumnName("message_status");

                entity.Property(e => e.MessageTextContent)
                      .HasColumnType("character varying")
                      .HasColumnName("message_text_content");
            });

            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Post>(entity => {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_post_id");

                entity.Property(e => e.UserId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_user_id");

                entity.Property(e => e.PathPictures)
                      .HasColumnType("text[]")
                      .HasColumnName("path_pictures");

                entity.Property(e => e.PathAudios)
                      .HasColumnType("text[]")
                      .HasColumnName("path_audios");

                entity.Property(e => e.SendDateTime)
                      .HasColumnName("send_date_time");

                entity.Property(e => e.PostTextContent)
                      .HasColumnType("character varying")
                      .HasColumnName("post_text_content");

                entity.Property(e => e.Title)
                      .HasColumnType("character varying")
                      .HasColumnName("title");
            });

            modelBuilder.Entity<Like>().ToTable("Likes");
            modelBuilder.Entity<Like>(entity => {
                entity.HasKey(e => e.LikeId);

                entity.Property(e => e.LikeId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_like_id");

                entity.Property(e => e.PostId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_post_id");

                entity.Property(e => e.UserId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_user_id");

                entity.HasOne(d => d.Post)
                      .WithMany(p => p.Likes)
                      .HasPrincipalKey(p => p.PostId)
                      .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>(entity => {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentId)
                      .HasColumnType("bigint")
                      .HasColumnName("pk_comment_id");

                entity.Property(e => e.UserId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_user_id");

                entity.Property(e => e.PostId)
                      .HasColumnType("bigint")
                      .HasColumnName("fk_post_id");

                entity.Property(e => e.CommentTextContent)
                      .HasColumnType("character varying")
                      .HasColumnName("comment_text_content");

                entity.Property(e => e.DatePublicate)
                      .HasColumnName("date_publicate");

                entity.Property(e => e.CommentStatus)
                      .HasColumnType("smallint")
                      .HasColumnName("comment_status");

                entity.HasOne(d => d.Post)
                      .WithMany(p => p.Comments)
                      .HasPrincipalKey(p => p.PostId)
                      .HasForeignKey(d => d.PostId);
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}