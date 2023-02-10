using DefaultMessager.DAL.EntityConfigurations.EntityTypes;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class DescriptionAccountConfig : IEntityTypeConfiguration<DescriptionAccount>
    {
        public void Configure(EntityTypeBuilder<DescriptionAccount> builder)
        {
            builder.ToTable("descriptions_accounts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_description_id");

            builder.Property(e => e.AccountId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account_id");

            builder.Property(e => e.Name)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("name");

            builder.Property(e => e.Surname)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("surname");

            builder.Property(e => e.Patronymic)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("patronymic");

            builder.Property(e => e.Describe)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("describe");

            builder.Property(e => e.UserStatus)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("description_status");

            builder.Property(e => e.PathAvatar)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("path_avatar");
        }
    }
}
