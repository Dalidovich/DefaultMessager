using DefaultMessager.DAL.EntityConfigurations.DataType;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    internal class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public const string Table_name = "comments";
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_comment_id");

            builder.Property(e => e.AccountId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account_id");

            builder.Property(e => e.PostId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_post_id");

            builder.Property(e => e.CommentTextContent)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("comment_text_content");

            builder.Property(e => e.DatePublicate)
                   .HasColumnName("date_publicate");

            builder.Property(e => e.CommentStatus)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("comment_status");

            builder.HasOne(d => d.Post)
                   .WithMany(p => p.Comments)
                   .HasPrincipalKey(p => p.Id)
                   .HasForeignKey(d => d.PostId);
        }
    }
}
