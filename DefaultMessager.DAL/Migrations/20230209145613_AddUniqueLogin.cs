using DefaultMessager.DAL.EntityConfigurations;
using DefaultMessager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DefaultMessager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint("unique_login", AccountConfig.Table_name, "login");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint("unique_login", AccountConfig.Table_name);
        }
    }
}
