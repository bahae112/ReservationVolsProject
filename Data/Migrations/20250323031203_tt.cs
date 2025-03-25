using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class tt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.AddColumn<string>(
                name: "Statut",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statut",
                table: "Reservations");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "C1", 0, "7518d586-4953-4107-9ace-5eae613f4ef0", null, false, false, null, null, null, null, null, false, "64f58a09-c4b4-4286-b88e-f2e009fc28d4", false, null },
                    { "C2", 0, "04ad075f-edfa-4527-9909-9ce8d2849592", null, false, false, null, null, null, null, null, false, "f7e3e685-147d-450f-bb88-3b9a905e2151", false, null }
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

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "clientId", "volId" },
                values: new object[,]
                {
                    { 1, "C1", 1 },
                    { 2, "C2", 2 }
                });
        }
    }
}
