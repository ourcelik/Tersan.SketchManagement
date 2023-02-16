using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tersan.SketchManagement.Migrations
{
    /// <inheritdoc />
    public partial class ShipStatusSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShipStatuses",
                columns: new[] { "ID", "StatusType" },
                values: new object[,]
                {
                    { 1, "Bakımda" },
                    { 2, "Üretimde" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShipStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShipStatuses",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
