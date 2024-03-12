using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemTest.Migrations
{
    /// <inheritdoc />
    public partial class updateRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orders_EmployeeId",
                table: "orders");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeId",
                table: "orders",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_orders_EmployeeId",
                table: "orders");

            migrationBuilder.CreateIndex(
                name: "IX_orders_EmployeeId",
                table: "orders",
                column: "EmployeeId",
                unique: true);
        }
    }
}
