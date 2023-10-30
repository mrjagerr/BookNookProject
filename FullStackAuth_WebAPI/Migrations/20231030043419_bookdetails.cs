using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class bookdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4261942-e70c-40e7-9b19-99a251fcdac1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea6bcd88-8b74-45ec-8f73-180be050b07a");

            migrationBuilder.AddColumn<int>(
                name: "FavoritesId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "611724e9-1d65-48db-abec-6556ab728da6", null, "User", "USER" },
                    { "a24f776e-bbd2-4b8f-aad6-c8947f9d468e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FavoritesId",
                table: "Reviews",
                column: "FavoritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Favorites_FavoritesId",
                table: "Reviews",
                column: "FavoritesId",
                principalTable: "Favorites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Favorites_FavoritesId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_FavoritesId",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "611724e9-1d65-48db-abec-6556ab728da6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a24f776e-bbd2-4b8f-aad6-c8947f9d468e");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "Reviews");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4261942-e70c-40e7-9b19-99a251fcdac1", null, "Admin", "ADMIN" },
                    { "ea6bcd88-8b74-45ec-8f73-180be050b07a", null, "User", "USER" }
                });
        }
    }
}
