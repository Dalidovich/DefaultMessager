using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthdayInDescriptionAndRenameUsersToAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropForeignKey(
                name: "FK_relations_users_fk_account1_id",
                table: "relations");

            migrationBuilder.DropForeignKey(
                name: "FK_relations_users_fk_account2_id",
                table: "relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "accounts");

            migrationBuilder.RenameIndex(
                name: "IX_users_login",
                table: "accounts",
                newName: "IX_accounts_login");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthday",
                table: "descriptions_accounts",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_accounts",
                table: "accounts",
                column: "pk_account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_accounts_fk_account_id",
                table: "comments",
                column: "fk_account_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_descriptions_accounts_accounts_fk_account_id",
                table: "descriptions_accounts",
                column: "fk_account_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_image_albums_accounts_fk_account_id",
                table: "image_albums",
                column: "fk_account_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_likes_accounts_fk_account_id",
                table: "likes",
                column: "fk_account_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_accounts_fk_recieve_id",
                table: "messages",
                column: "fk_recieve_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messages_accounts_fk_sender_id",
                table: "messages",
                column: "fk_sender_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_accounts_fk_account_id",
                table: "posts",
                column: "fk_account_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_relations_accounts_fk_account1_id",
                table: "relations",
                column: "fk_account1_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_relations_accounts_fk_account2_id",
                table: "relations",
                column: "fk_account2_id",
                principalTable: "accounts",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_accounts_fk_account_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_descriptions_accounts_accounts_fk_account_id",
                table: "descriptions_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_image_albums_accounts_fk_account_id",
                table: "image_albums");

            migrationBuilder.DropForeignKey(
                name: "FK_likes_accounts_fk_account_id",
                table: "likes");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_accounts_fk_recieve_id",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_messages_accounts_fk_sender_id",
                table: "messages");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_accounts_fk_account_id",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_relations_accounts_fk_account1_id",
                table: "relations");

            migrationBuilder.DropForeignKey(
                name: "FK_relations_accounts_fk_account2_id",
                table: "relations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_accounts",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "birthday",
                table: "descriptions_accounts");

            migrationBuilder.RenameTable(
                name: "accounts",
                newName: "users");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_login",
                table: "users",
                newName: "IX_users_login");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "pk_account_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_relations_users_fk_account1_id",
                table: "relations",
                column: "fk_account1_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_relations_users_fk_account2_id",
                table: "relations",
                column: "fk_account2_id",
                principalTable: "users",
                principalColumn: "pk_account_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
