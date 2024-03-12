using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SystemTest.Migrations.UserSystemTest
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41db5eea-2be2-45d0-931e-851d1b2d3c77", "eaca1b20-da6b-47cb-b6cc-d09afa3842e2", "Admin", "admin" },
                    { "c5a9f6cb-5d76-4dfe-86d0-5779a6d6625c", "9fa5c7de-d340-42b2-9171-837fd143ed20", "Employee", "employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41db5eea-2be2-45d0-931e-851d1b2d3c77");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5a9f6cb-5d76-4dfe-86d0-5779a6d6625c");
        }
    }
}
