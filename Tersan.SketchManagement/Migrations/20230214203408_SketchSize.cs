using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tersan.SketchManagement.Migrations
{
    /// <inheritdoc />
    public partial class SketchSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HexColorCode",
                table: "Ships",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Ships");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "HexColorCode",
                table: "Ships",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);
        }
    }
}
