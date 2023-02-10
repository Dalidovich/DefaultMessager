using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_fk_post_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_users_fk_account_id",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_users_users_fk_account_id",
                table: "Descriptions_users");

            migrationBuilder.DropForeignKey(
                name: "FK_Image_albums_users_fk_account_id",
                table: "Image_albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Posts_fk_post_id",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_users_fk_account_id",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_users_fk_recieve_id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_users_fk_sender_id",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_users_fk_account_id",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Image_albums",
                table: "Image_albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Descriptions_users",
                table: "Descriptions_users");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "messages");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "likes");

            migrationBuilder.RenameTable(
                name: "Image_albums",
                newName: "image_albums");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "comments");

            migrationBuilder.RenameTable(
                name: "Descriptions_users",
                newName: "descriptions_accounts");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_fk_account_id",
                table: "posts",
                newName: "IX_posts_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_fk_sender_id",
                table: "messages",
                newName: "IX_messages_fk_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_fk_recieve_id",
                table: "messages",
                newName: "IX_messages_fk_recieve_id");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_fk_post_id",
                table: "likes",
                newName: "IX_likes_fk_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_fk_account_id",
                table: "likes",
                newName: "IX_likes_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Image_albums_fk_account_id",
                table: "image_albums",
                newName: "IX_image_albums_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_fk_post_id",
                table: "comments",
                newName: "IX_comments_fk_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_fk_account_id",
                table: "comments",
                newName: "IX_comments_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Descriptions_users_fk_account_id",
                table: "descriptions_accounts",
                newName: "IX_descriptions_accounts_fk_account_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "pk_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_messages",
                table: "messages",
                column: "pk_message_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_likes",
                table: "likes",
                column: "pk_like_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_image_albums",
                table: "image_albums",
                column: "pk_image_album_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "comments",
                column: "pk_comment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_descriptions_accounts",
                table: "descriptions_accounts",
                column: "pk_description_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                table: "users",
                column: "login");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_fk_post_id",
                table: "comments",
                column: "fk_post_id",
                principalTable: "posts",
                principalColumn: "pk_post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_fk_account_id",
                table: "comments",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_descriptions_accounts_users_fk_account_id",
                table: "descriptions_accounts",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_image_albums_users_fk_account_id",
                table: "image_albums",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_posts_fk_post_id",
                table: "likes",
                column: "fk_post_id",
                principalTable: "posts",
                principalColumn: "pk_post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_users_fk_account_id",
                table: "likes",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_users_fk_recieve_id",
                table: "messages",
                column: "fk_recieve_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_users_fk_sender_id",
                table: "messages",
                column: "fk_sender_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_fk_account_id",
                table: "posts",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_fk_post_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_fk_account_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_descriptions_accounts_users_fk_account_id",
                table: "descriptions_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_image_albums_users_fk_account_id",
                table: "image_albums");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_posts_fk_post_id",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_users_fk_account_id",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_fk_recieve_id",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_users_fk_sender_id",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_fk_account_id",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_users_login",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_messages",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_likes",
                table: "likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_image_albums",
                table: "image_albums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_descriptions_accounts",
                table: "descriptions_accounts");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "messages",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "likes",
                newName: "Likes");

            migrationBuilder.RenameTable(
                name: "image_albums",
                newName: "Image_albums");

            migrationBuilder.RenameTable(
                name: "comments",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "descriptions_accounts",
                newName: "Descriptions_users");

            migrationBuilder.RenameIndex(
                name: "IX_posts_fk_account_id",
                table: "Posts",
                newName: "IX_Posts_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_messages_fk_sender_id",
                table: "Messages",
                newName: "IX_Messages_fk_sender_id");

            migrationBuilder.RenameIndex(
                name: "IX_messages_fk_recieve_id",
                table: "Messages",
                newName: "IX_Messages_fk_recieve_id");

            migrationBuilder.RenameIndex(
                name: "IX_likes_fk_post_id",
                table: "Likes",
                newName: "IX_Likes_fk_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_likes_fk_account_id",
                table: "Likes",
                newName: "IX_Likes_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_image_albums_fk_account_id",
                table: "Image_albums",
                newName: "IX_Image_albums_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_fk_post_id",
                table: "Comments",
                newName: "IX_Comments_fk_post_id");

            migrationBuilder.RenameIndex(
                name: "IX_comments_fk_account_id",
                table: "Comments",
                newName: "IX_Comments_fk_account_id");

            migrationBuilder.RenameIndex(
                name: "IX_descriptions_accounts_fk_account_id",
                table: "Descriptions_users",
                newName: "IX_Descriptions_users_fk_account_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "pk_post_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "pk_message_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "pk_like_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Image_albums",
                table: "Image_albums",
                column: "pk_image_album_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "pk_comment_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Descriptions_users",
                table: "Descriptions_users",
                column: "pk_description_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_fk_post_id",
                table: "Comments",
                column: "fk_post_id",
                principalTable: "Posts",
                principalColumn: "pk_post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_users_fk_account_id",
                table: "Comments",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_users_users_fk_account_id",
                table: "Descriptions_users",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_albums_users_fk_account_id",
                table: "Image_albums",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Posts_fk_post_id",
                table: "Likes",
                column: "fk_post_id",
                principalTable: "Posts",
                principalColumn: "pk_post_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_users_fk_account_id",
                table: "Likes",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_users_fk_recieve_id",
                table: "Messages",
                column: "fk_recieve_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_users_fk_sender_id",
                table: "Messages",
                column: "fk_sender_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_users_fk_account_id",
                table: "Posts",
                column: "fk_account_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
