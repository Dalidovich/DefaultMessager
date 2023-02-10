using DefaultMessager.DAL.EntityConfigurations.EntityTypes;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class MessageConfig : IEntityTypeConfiguration<Message>
    {
        public const string Table_name = "messages";
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_message_id");

            builder.Property(e => e.RecieveId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_recieve_id");

            builder.Property(e => e.SenderId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_sender_id");

            builder.Property(e => e.PathPictures)
                   .HasColumnType(EntityDataTypes.Text_array)
                   .HasColumnName("path_pictures");

            builder.Property(e => e.PathAudios)
                   .HasColumnType(EntityDataTypes.Text_array)
                   .HasColumnName("path_audios");

            builder.Property(e => e.SendDateTime)
                   .HasColumnName("send_date_time");

            builder.Property(e => e.MessageStatus)
                   .HasColumnType(EntityDataTypes.Smallint)
                   .HasColumnName("message_status");

            builder.Property(e => e.MessageTextContent)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("message_text_content");
            }
    }
}
