using DefaultMessager.DAL.EntityConfigurations.EntityTypes;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class LikeConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_like_id");

            builder.Property(e => e.PostId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_post_id");

            builder.Property(e => e.UserId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_user_id");

            builder.HasOne(d => d.Post)
                   .WithMany(p => p.Likes)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.PostId);
        }
    }
}
