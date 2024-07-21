using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class berater_taetigkeit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berater_Projekt_Taetigkeiten");

            migrationBuilder.CreateTable(
                name: "Berater_Projekt_Taetigkeit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeraterProjektId = table.Column<int>(type: "int", nullable: false),
                    TaetigkeitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berater_Projekt_Taetigkeit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Berater_Projekt_Taetigkeit_Berater_Projekten_BeraterProjektId",
                        column: x => x.BeraterProjektId,
                        principalTable: "Berater_Projekten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Berater_Projekt_Taetigkeit_Taetigkeiten_TaetigkeitId",
                        column: x => x.TaetigkeitId,
                        principalTable: "Taetigkeiten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekt_Taetigkeit_BeraterProjektId",
                table: "Berater_Projekt_Taetigkeit",
                column: "BeraterProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekt_Taetigkeit_TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit",
                column: "TaetigkeitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berater_Projekt_Taetigkeit");

            migrationBuilder.CreateTable(
                name: "Berater_Projekt_Taetigkeiten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeraterProjektId = table.Column<int>(type: "int", nullable: false),
                    TaetigkeitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berater_Projekt_Taetigkeiten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Berater_Projekt_Taetigkeiten_Berater_Projekten_BeraterProjek~",
                        column: x => x.BeraterProjektId,
                        principalTable: "Berater_Projekten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Berater_Projekt_Taetigkeiten_Taetigkeiten_TaetigkeitId",
                        column: x => x.TaetigkeitId,
                        principalTable: "Taetigkeiten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekt_Taetigkeiten_BeraterProjektId",
                table: "Berater_Projekt_Taetigkeiten",
                column: "BeraterProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekt_Taetigkeiten_TaetigkeitId",
                table: "Berater_Projekt_Taetigkeiten",
                column: "TaetigkeitId");
        }
    }
}
