using DefaultMessager.DAL.EntityConfigurations.EntityTypes;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class ImageAlbumConfig : IEntityTypeConfiguration<ImageAlbum>
    {
        public void Configure(EntityTypeBuilder<ImageAlbum> builder)
        {
            builder.ToTable("image_albums");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_image_album_id");

            builder.Property(e => e.AccountId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account_id");

            builder.Property(e => e.PathPictures)
                   .HasColumnType(EntityDataTypes.Text_array)
                   .HasColumnName("path_pictures");

            builder.Property(e => e.Title)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("title");
        }
    }
}
