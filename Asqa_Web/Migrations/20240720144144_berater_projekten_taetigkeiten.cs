using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class berater_projekten_taetigkeiten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropColumn(
                name: "TaetigkeitenDescriptions",
                table: "Ma_Projekte");*/

            migrationBuilder.CreateTable(
                name: "Berater_Projekten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MitarbeiterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProjektId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Berater_Projekten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Berater_Projekten_Mitarbeiter_MitarbeiterId",
                        column: x => x.MitarbeiterId,
                        principalTable: "Mitarbeiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Berater_Projekten_Projekten_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekten_MitarbeiterId",
                table: "Berater_Projekten",
                column: "MitarbeiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekten_ProjektId",
                table: "Berater_Projekten",
                column: "ProjektId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Berater_Projekt_Taetigkeiten");

            migrationBuilder.DropTable(
                name: "Berater_Projekten");

            migrationBuilder.AddColumn<string>(
                name: "TaetigkeitenDescriptions",
                table: "Ma_Projekte",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
