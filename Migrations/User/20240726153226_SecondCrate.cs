using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApp.Migrations.User
{
    /// <inheritdoc />
    public partial class SecondCrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "account");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "users",
                newSchema: "account");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "users",
                schema: "account",
                newName: "users");
        }
    }
}
