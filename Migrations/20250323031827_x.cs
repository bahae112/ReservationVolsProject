using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class x : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "C1", 0, "de912fca-4461-430c-94f5-2071b7055cf4", null, false, false, null, null, null, null, null, false, "f4bf1099-1946-472e-9377-571ed653ebcd", false, null },
                    { "C2", 0, "bb2660aa-b820-4678-af6e-8cc7fb64e49c", null, false, false, null, null, null, null, null, false, "71ec513b-7bab-4385-8a3e-0c95709e7517", false, null }
                });

            migrationBuilder.InsertData(
                table: "Vols",
                columns: new[] { "Id", "dateArrivee", "dateDepart", "destination", "départ", "nombrePalces", "prix" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "Paris", "Casablanca", 150, 1200f },
                    { 2, new DateTime(2024, 9, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "New York", "Marrakech", 200, 4500f }
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
                table: "Vols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C2");
        }
    }
}
