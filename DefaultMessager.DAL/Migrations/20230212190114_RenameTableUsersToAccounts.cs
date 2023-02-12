using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RenameTableUsersToAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                newName: "accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                            name: "accounts",
                            newName: "users");
        }
    }
}
