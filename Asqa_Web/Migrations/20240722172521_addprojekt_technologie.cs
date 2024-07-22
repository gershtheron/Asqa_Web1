using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class addprojekt_technologie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projekt_Technologie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjektId = table.Column<int>(type: "int", nullable: false),
                    TechnologieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt_Technologie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projekt_Technologie_Projekten_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projekt_Technologie_Technologie_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_Technologie_ProjektId",
                table: "Projekt_Technologie",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_Technologie_TechnologieId",
                table: "Projekt_Technologie",
                column: "TechnologieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projekt_Technologie");
        }
    }
}
