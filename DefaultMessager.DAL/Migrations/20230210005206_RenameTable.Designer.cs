﻿// <auto-generated />
using System;
using DefaultMessager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    [DbContext(typeof(MessagerDbContext))]
    [Migration("20230210005206_RenameTable")]
    partial class RenameTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Account", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_account_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("email");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("password");

                    b.Property<short>("Role")
                        .HasColumnType("smallint")
                        .HasColumnName("role");

                    b.Property<short>("StatusAccount")
                        .HasColumnType("smallint")
                        .HasColumnName("status_account");

                    b.HasKey("Id");

                    b.HasIndex("Login");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_comment_id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_account_id");

                    b.Property<short>("CommentStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("comment_status");

                    b.Property<string>("CommentTextContent")
                        .HasColumnType("character varying")
                        .HasColumnName("comment_text_content");

                    b.Property<DateTime>("DatePublicate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_publicate");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_post_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.DescriptionAccount", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_description_id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_account_id");

                    b.Property<string>("Describe")
                        .HasColumnType("character varying")
                        .HasColumnName("describe");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("PathAvatar")
                        .HasColumnType("character varying")
                        .HasColumnName("path_avatar");

                    b.Property<string>("Patronymic")
                        .HasColumnType("character varying")
                        .HasColumnName("patronymic");

                    b.Property<string>("Surname")
                        .HasColumnType("character varying")
                        .HasColumnName("surname");

                    b.Property<string>("UserStatus")
                        .HasColumnType("character varying")
                        .HasColumnName("description_status");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("descriptions_accounts", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.ImageAlbum", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_image_album_id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_account_id");

                    b.Property<string[]>("PathPictures")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("path_pictures");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("image_albums", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Like", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_like_id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_account_id");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_post_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("PostId");

                    b.ToTable("likes", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Message", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_message_id");

                    b.Property<short>("MessageStatus")
                        .HasColumnType("smallint")
                        .HasColumnName("message_status");

                    b.Property<string>("MessageTextContent")
                        .HasColumnType("character varying")
                        .HasColumnName("message_text_content");

                    b.Property<string[]>("PathAudios")
                        .HasColumnType("text[]")
                        .HasColumnName("path_audios");

                    b.Property<string[]>("PathPictures")
                        .HasColumnType("text[]")
                        .HasColumnName("path_pictures");

                    b.Property<Guid>("RecieveId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_recieve_id");

                    b.Property<DateTime>("SendDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("send_date_time");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_sender_id");

                    b.HasKey("Id");

                    b.HasIndex("RecieveId");

                    b.HasIndex("SenderId");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Post", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("pk_post_id");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("fk_account_id");

                    b.Property<string[]>("PathAudios")
                        .HasColumnType("text[]")
                        .HasColumnName("path_audios");

                    b.Property<string[]>("PathPictures")
                        .HasColumnType("text[]")
                        .HasColumnName("path_pictures");

                    b.Property<string>("PostTextContent")
                        .HasColumnType("character varying")
                        .HasColumnName("post_text_content");

                    b.Property<DateTime>("SendDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("send_date_time");

                    b.Property<string>("Title")
                        .HasColumnType("character varying")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("posts", (string)null);
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Comment", b =>
                {
                    b.HasOne("DefaultMessager.Domain.Entities.Account", "User")
                        .WithMany("Comments")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefaultMessager.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.DescriptionAccount", b =>
                {
                    b.HasOne("DefaultMessager.Domain.Entities.Account", "User")
                        .WithOne("Description")
                        .HasForeignKey("DefaultMessager.Domain.Entities.DescriptionAccount", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.ImageAlbum", b =>
                {
                    b.HasOne("DefaultMessager.Domain.Entities.Account", "User")
                        .WithMany("ImageAlbum")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Like", b =>
                {
                    b.HasOne("DefaultMessager.Domain.Entities.Account", "User")
                        .WithMany("Likes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefaultMessager.Domain.Entities.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Message", b =>
                {
                    b.HasOne("DefaultMessager.Domain.Entities.Account", "Reciever")
                        .WithMany("ReciveMessages")
                        .HasForeignKey("RecieveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DefaultMessager.Domain.Entities.Account", "Sender")
                        .WithMany("SendMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reciever");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Post", b =>
                {
                    b.HasOne("DefaultMessager.Domain.Entities.Account", "User")
                        .WithMany("Posts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Account", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Description");

                    b.Navigation("ImageAlbum");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("ReciveMessages");

                    b.Navigation("SendMessages");
                });

            modelBuilder.Entity("DefaultMessager.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
