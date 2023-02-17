using DefaultMessager.DAL.EntityConfigurations.DataType;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class RefreshTocenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public const string Table_name = "refresh_tokens";
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });
            builder.HasIndex(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_refresh_token_id");

            builder.Property(e => e.AccountId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account_id");

            builder.Property(e => e.Token)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("refresh_token");
        }
    }
}
