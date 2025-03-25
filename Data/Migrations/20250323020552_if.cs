using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class @if : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "C1", 0, "42360399-d7ba-4c9d-a4f7-0cf16df6a6e5", null, false, false, null, null, null, null, null, false, "a7319bf0-9c65-49ce-af7d-04cdfea91894", false, null },
                    { "C2", 0, "ff447c4b-8ec7-4436-8b6d-66f703632829", null, false, false, null, null, null, null, null, false, "df3af595-968d-4416-aa74-07fa8e268c60", false, null },
                    { "G1", 0, "67f95d6e-8589-4377-98d2-b92a71aee3a2", null, false, false, null, null, null, null, null, false, "e7321014-735c-4b68-b966-6ec428ad215c", false, null },
                    { "G2", 0, "88ef47d3-e3b7-4179-92c4-9e0444f31b38", null, false, false, null, null, null, null, null, false, "8c10ce16-311c-4d9e-89ac-9150297de94c", false, null }
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
                table: "Gestionnaires",
                columns: new[] { "Id", "CIN", "Code", "Nom", "Prenom", "anneeRecrutement" },
                values: new object[,]
                {
                    { "G1", "EF345678", "GEST2023", "Rahmani", "Omar", new DateOnly(2023, 1, 1) },
                    { "G2", "GH901234", "GEST2022", "Zahraoui", "Amina", new DateOnly(2022, 1, 1) }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G2");

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
        }
    }
}
