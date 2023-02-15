using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldRefreshTokenToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "refresh_token",
                table: "accounts",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "refresh_token",
                table: "accounts");
        }
    }
}
