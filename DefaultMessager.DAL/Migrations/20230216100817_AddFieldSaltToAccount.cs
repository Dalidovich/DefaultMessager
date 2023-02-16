using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldSaltToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "accounts",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "accounts");
        }
    }
}
