using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace reservation_vols.Migrations
{
    /// <inheritdoc />
    public partial class iv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7518d586-4953-4107-9ace-5eae613f4ef0", "64f58a09-c4b4-4286-b88e-f2e009fc28d4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "C2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04ad075f-edfa-4527-9909-9ce8d2849592", "f7e3e685-147d-450f-bb88-3b9a905e2151" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
