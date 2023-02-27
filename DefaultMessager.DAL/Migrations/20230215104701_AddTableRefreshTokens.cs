using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTableRefreshTokens : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "accounts");

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    pkrefreshtokenid = table.Column<Guid>(name: "pk_refresh_token_id", type: "uuid", nullable: false),
                    fkaccountid = table.Column<Guid>(name: "fk_account_id", type: "uuid", nullable: false),
                    refreshtoken = table.Column<string>(name: "refresh_token", type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_tokens", x => x.pkrefreshtokenid);
                    table.ForeignKey(
                        name: "FK_refresh_tokens_accounts_fk_account_id",
                        column: x => x.fkaccountid,
                        principalTable: "accounts",
                        principalColumn: "pk_account_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_fk_account_id",
                table: "refresh_tokens",
                column: "fk_account_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refresh_tokens_pk_refresh_token_id",
                table: "refresh_tokens",
                column: "pk_refresh_token_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "accounts",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }
    }
}
