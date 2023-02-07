using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tersan.SketchManagement.Migrations
{
    /// <inheritdoc />
    public partial class SketchUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sketches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Sketches",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sketches");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Sketches");
        }
    }
}
