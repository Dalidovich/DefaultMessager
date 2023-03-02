using DefaultMessager.DAL.EntityConfigurations.DataType;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public const string Table_name = "accounts";
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });
            builder.HasIndex(e => e.Login);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_account_id");

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

            builder.Property(e => e.Salt)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("salt");

            builder.HasMany(d => d.ImageAlbum)
                   .WithOne(p => p.Account)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.AccountId);

            builder.HasMany(d => d.Posts)
                   .WithOne(p => p.Account)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.AccountId);

            builder.HasMany(d => d.SendMessages)
                   .WithOne(p => p.Sender)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.SenderId);

            builder.HasMany(d => d.ReciveMessages)
                   .WithOne(p => p.Reciever)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.RecieveId);

            builder.HasMany(d => d.Likes)
                   .WithOne(p => p.Account)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.AccountId);

            builder.HasMany(d => d.Comments)
                   .WithOne(p => p.Account)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.AccountId);

            builder.HasOne(d => d.Description)
                   .WithOne(p => p.Account)
                   .HasPrincipalKey<Account>(p => p.Id)
                   .HasForeignKey<DescriptionAccount>(d => d.AccountId);

            builder.HasOne(d => d.RefreshToken)
                   .WithOne(p => p.Account)
                   .HasPrincipalKey<Account>(p => p.Id)
                   .HasForeignKey<RefreshToken>(d => d.AccountId);

            builder.HasMany(d => d.RelationsFrom)
                   .WithOne(p => p.Account1)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.AccountId1);

            builder.HasMany(d => d.RelationsTo)
                   .WithOne(p => p.Account2)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.AccountId2);
        }
    }
}
