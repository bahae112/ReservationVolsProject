using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class yx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fec36286-74bb-4900-8184-079332f00ec1", "ae177cd6-9cfa-4f2c-8289-70c5f959024b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "77d13785-4c4b-4133-80c0-e053f7bbb05c", "1e341f1f-d870-4bff-9620-9897223ed527" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "42360399-d7ba-4c9d-a4f7-0cf16df6a6e5", "a7319bf0-9c65-49ce-af7d-04cdfea91894" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff447c4b-8ec7-4436-8b6d-66f703632829", "df3af595-968d-4416-aa74-07fa8e268c60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67f95d6e-8589-4377-98d2-b92a71aee3a2", "e7321014-735c-4b68-b966-6ec428ad215c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "G2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "88ef47d3-e3b7-4179-92c4-9e0444f31b38", "8c10ce16-311c-4d9e-89ac-9150297de94c" });
        }
    }
}
