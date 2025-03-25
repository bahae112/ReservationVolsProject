using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class lk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Gestionnaires",
                keyColumn: "Id",
                keyValue: "G1");

            migrationBuilder.DeleteData(
                table: "Gestionnaires",
                keyColumn: "Id",
                keyValue: "G2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b8d129ad-a94c-4732-85fe-0af28083ae16", "ccec445a-5520-4a64-b0b9-65e62c2f5bab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0491a88b-f78c-4429-9a78-05764003b90b", "25a7a3a8-0379-4a99-8a13-906078520a89" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e80a6383-1dba-4c9e-8041-7ea3fc9ddce2", "a72203fd-6bac-4beb-b314-4955a22b3db7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "771cbbdf-174d-43c9-9c3b-ee81761db38d", "9a67bc3d-6ce0-4f1f-86d8-8349ded9d88a" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "G1", 0, "fec36286-74bb-4900-8184-079332f00ec1", null, false, false, null, null, null, null, null, false, "ae177cd6-9cfa-4f2c-8289-70c5f959024b", false, null },
                    { "G2", 0, "77d13785-4c4b-4133-80c0-e053f7bbb05c", null, false, false, null, null, null, null, null, false, "1e341f1f-d870-4bff-9620-9897223ed527", false, null }
                });

            migrationBuilder.InsertData(
                table: "Gestionnaires",
                columns: new[] { "Id", "CIN", "Code", "Nom", "Prenom", "anneeRecrutement" },
                values: new object[,]
                {
                    { "G1", "EF345678", "GEST2023", "Rahmani", "Omar", new DateOnly(2023, 1, 1) },
                    { "G2", "GH901234", "GEST2022", "Zahraoui", "Amina", new DateOnly(2022, 1, 1) }
                });
        }
    }
}
