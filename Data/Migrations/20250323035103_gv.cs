using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class gv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "C1");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "C2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C2");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "10d204d0-add8-4d2b-b0f8-88207b7e42bf", 0, "3eef7f31-c510-4a70-92b2-72a1e6bbaf89", null, false, false, null, null, null, null, null, false, "0129fe09-99af-47fb-9535-ad29265953bb", false, null },
                    { "3a93721f-8c90-4c8d-86e9-9ab2ee8acf03", 0, "f82627c1-b853-49c4-b643-75b5fa333952", null, false, false, null, null, null, null, null, false, "dab9808b-0ead-43f4-9a7a-1ea215106bb1", false, null }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CIN", "Nom", "Prenom", "TypeClient" },
                values: new object[,]
                {
                    { "10d204d0-add8-4d2b-b0f8-88207b7e42bf", "CD789012", "Bennani", "Sofia", "Régulier" },
                    { "3a93721f-8c90-4c8d-86e9-9ab2ee8acf03", "AB123456", "El Amrani", "Yassine", "VIP" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "10d204d0-add8-4d2b-b0f8-88207b7e42bf");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: "3a93721f-8c90-4c8d-86e9-9ab2ee8acf03");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "10d204d0-add8-4d2b-b0f8-88207b7e42bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a93721f-8c90-4c8d-86e9-9ab2ee8acf03");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "C1", 0, "706e0cf4-2ac6-4c82-b234-f96023b79fa9", null, false, false, null, null, null, null, null, false, "cd2f0bfa-cfc9-430c-aa38-5787b5884d44", false, null },
                    { "C2", 0, "7f0401c2-4d9e-4dfa-9a36-31468b65f1e8", null, false, false, null, null, null, null, null, false, "535d3259-42fb-47f5-861a-1696c2164b72", false, null }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CIN", "Nom", "Prenom", "TypeClient" },
                values: new object[,]
                {
                    { "C1", "AB123456", "El Amrani", "Yassine", "VIP" },
                    { "C2", "CD789012", "Bennani", "Sofia", "Régulier" }
                });
        }
    }
}
