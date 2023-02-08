using DefaultMessager.DAL.EntityConfigurations.EntityTypes;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => new { e.Id });

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_user_id");

            builder.Property(e => e.Email)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("email");

            builder.Property(e => e.Login)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("login");

            builder.Property(e => e.Password)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("password");

            builder.Property(e => e.Role)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("role");

            builder.Property(e => e.CreateDate)
                   .HasColumnName("create_date");

            builder.Property(e => e.StatusAccount)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("status_account");

            builder.HasMany(d => d.ImageAlbum)
                   .WithOne(p => p.User)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.UserId);

            builder.HasMany(d => d.Posts)
                   .WithOne(p => p.User)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.UserId);

            builder.HasMany(d => d.SendMessages)
                   .WithOne(p => p.Sender)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.SenderId);

            builder.HasMany(d => d.ReciveMessages)
                   .WithOne(p => p.Reciever)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.RecieveId);

            builder.HasMany(d => d.Likes)
                   .WithOne(p => p.User)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.UserId);

            builder.HasMany(d => d.Comments)
                   .WithOne(p => p.User)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.UserId);
             
            builder.HasOne(d => d.Description)
                   .WithOne(p => p.User)
                   .HasPrincipalKey<User>(p => p.Id)
                   .HasForeignKey<DescriptionUser>(d => d.UserId);
        }
    }
}
