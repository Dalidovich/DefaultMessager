﻿using DefaultMessager.DAL.EntityConfigurations.DataType;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DefaultMessager.DAL.EntityConfigurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public const string Table_name = "posts";
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_post_id");

            builder.Property(e => e.AccountId)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("fk_account_id");

            builder.Property(e => e.PathPictures)
                   .HasColumnType(EntityDataTypes.Text_array)
                   .HasColumnName("path_pictures");

            builder.Property(e => e.PathAudios)
                   .HasColumnType(EntityDataTypes.Text_array)
                   .HasColumnName("path_audios");

            builder.Property(e => e.SendDateTime)
                   .HasColumnName("send_date_time");

            builder.Property(e => e.PostTextContent)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("post_text_content");

            builder.Property(e => e.Title)
                   .HasColumnType(EntityDataTypes.Character_varying)
                   .HasColumnName("title");
        }
    }
}
