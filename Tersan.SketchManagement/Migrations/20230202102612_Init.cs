using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tersan.SketchManagement.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShipStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sketches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sketches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SketchID = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buildings_Sketches_SketchID",
                        column: x => x.SketchID,
                        principalTable: "Sketches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipStatusID = table.Column<int>(type: "int", nullable: false),
                    SketchID = table.Column<int>(type: "int", nullable: false),
                    ShipStatusID1 = table.Column<int>(type: "int", nullable: true),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStatuses_ShipStatusID",
                        column: x => x.ShipStatusID,
                        principalTable: "ShipStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ships_ShipStatuses_ShipStatusID1",
                        column: x => x.ShipStatusID1,
                        principalTable: "ShipStatuses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Ships_Sketches_SketchID",
                        column: x => x.SketchID,
                        principalTable: "Sketches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingID = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Offices_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OfficeID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeID1",
                        column: x => x.OfficeID1,
                        principalTable: "Offices",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserCredentials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    CredentialID = table.Column<int>(type: "int", nullable: false),
                    CredentialID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCredentials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserCredentials_Credentials_CredentialID",
                        column: x => x.CredentialID,
                        principalTable: "Credentials",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCredentials_Credentials_CredentialID1",
                        column: x => x.CredentialID1,
                        principalTable: "Credentials",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserCredentials_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_SketchID",
                table: "Buildings",
                column: "SketchID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeID",
                table: "Employees",
                column: "OfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeID1",
                table: "Employees",
                column: "OfficeID1");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_BuildingID",
                table: "Offices",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipStatusID",
                table: "Ships",
                column: "ShipStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_ShipStatusID1",
                table: "Ships",
                column: "ShipStatusID1");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_SketchID",
                table: "Ships",
                column: "SketchID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_CredentialID",
                table: "UserCredentials",
                column: "CredentialID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_CredentialID1",
                table: "UserCredentials",
                column: "CredentialID1");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_EmployeeID",
                table: "UserCredentials",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "UserCredentials");

            migrationBuilder.DropTable(
                name: "ShipStatuses");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Sketches");
        }
    }
}
