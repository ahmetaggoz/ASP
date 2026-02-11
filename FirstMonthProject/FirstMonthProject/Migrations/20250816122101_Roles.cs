using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstMonthProject.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e961b8b8-0750-4f95-a26e-447ed61d5cb3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f39be10e-5f75-4d1c-8fb5-69d119487628");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f77a7adc-1c64-49d5-929f-65744bd0fb99");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3", null, "Author", "AUTHOR" },
                    { "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a", null, "Admin", "ADMIN" },
                    { "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e961b8b8-0750-4f95-a26e-447ed61d5cb3", null, "User", "USER" },
                    { "f39be10e-5f75-4d1c-8fb5-69d119487628", null, "Admin", "ADMIN" },
                    { "f77a7adc-1c64-49d5-929f-65744bd0fb99", null, "Author", "AUTHOR" }
                });
        }
    }
}
