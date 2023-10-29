using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class favorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0816cb7c-6df6-4226-bd28-6f9d3aefecc2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "307f20c4-8ad0-4e04-a159-2ac3dde955a1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14644f72-47ea-4895-a93a-134b1629a1e7", null, "User", "USER" },
                    { "36db6f67-d016-4f6f-b4d0-2c0bdc0af91c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14644f72-47ea-4895-a93a-134b1629a1e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36db6f67-d016-4f6f-b4d0-2c0bdc0af91c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0816cb7c-6df6-4226-bd28-6f9d3aefecc2", null, "Admin", "ADMIN" },
                    { "307f20c4-8ad0-4e04-a159-2ac3dde955a1", null, "User", "USER" }
                });
        }
    }
}
