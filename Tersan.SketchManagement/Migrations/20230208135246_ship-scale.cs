using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tersan.SketchManagement.Migrations
{
    /// <inheritdoc />
    public partial class shipscale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WindowHeight",
                table: "Ships",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WindowWidth",
                table: "Ships",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WindowHeight",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "WindowWidth",
                table: "Ships");
        }
    }
}
