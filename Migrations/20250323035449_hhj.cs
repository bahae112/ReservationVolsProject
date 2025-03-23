using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class hhj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "C1", 0, "16b48d58-1638-4daa-baeb-73722576b0ef", null, false, false, null, null, null, null, null, false, "a6b92b32-d2c1-40bf-8f77-80125b9db9a9", false, null },
                    { "C2", 0, "bf880c7c-58fa-43fc-baaa-4345da50bbd3", null, false, false, null, null, null, null, null, false, "f8eb39ef-fdae-4122-8331-d05147eead15", false, null }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
