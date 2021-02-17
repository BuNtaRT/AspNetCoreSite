using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LPFO_one.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID_service = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID_service);
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    ID_spec = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Worked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.ID_spec);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    ID_unit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.ID_unit);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phone_num = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitID_unit = table.Column<int>(type: "int", nullable: true),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID_user);
                    table.ForeignKey(
                        name: "FK_Users_Units_UnitID_unit",
                        column: x => x.UnitID_unit,
                        principalTable: "Units",
                        principalColumn: "ID_unit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID_note = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersID_user = table.Column<int>(type: "int", nullable: true),
                    SpecID_spec = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID_note);
                    table.ForeignKey(
                        name: "FK_Notes_Specs_SpecID_spec",
                        column: x => x.SpecID_spec,
                        principalTable: "Specs",
                        principalColumn: "ID_spec",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UsersID_user",
                        column: x => x.UsersID_user,
                        principalTable: "Users",
                        principalColumn: "ID_user",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteServicesU",
                columns: table => new
                {
                    NotesID_note = table.Column<int>(type: "int", nullable: false),
                    ServicesID_service = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteServicesU", x => new { x.NotesID_note, x.ServicesID_service });
                    table.ForeignKey(
                        name: "FK_NoteServicesU_Notes_NotesID_note",
                        column: x => x.NotesID_note,
                        principalTable: "Notes",
                        principalColumn: "ID_note",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteServicesU_Services_ServicesID_service",
                        column: x => x.ServicesID_service,
                        principalTable: "Services",
                        principalColumn: "ID_service",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_SpecID_spec",
                table: "Notes",
                column: "SpecID_spec");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UsersID_user",
                table: "Notes",
                column: "UsersID_user");

            migrationBuilder.CreateIndex(
                name: "IX_NoteServicesU_ServicesID_service",
                table: "NoteServicesU",
                column: "ServicesID_service");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UnitID_unit",
                table: "Users",
                column: "UnitID_unit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteServicesU");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
