using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class ux : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vols",
                columns: new[] { "Id", "dateArrivee", "dateDepart", "destination", "départ", "nombrePalces", "prix" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 14, 30, 0, 0, DateTimeKind.Unspecified), "Paris", "Casablanca", 150, 1200f },
                    { 2, new DateTime(2024, 9, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), "New York", "Marrakech", 200, 4500f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
