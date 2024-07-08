using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class ma_technologie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ma_Technologien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MitarbeiterId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TechnologieId = table.Column<int>(type: "int", nullable: false),
                    KompetenzId = table.Column<int>(type: "int", nullable: false),
                    Komp_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeitJahr = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ma_Technologien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ma_Technologien_Kompetenzen_KompetenzId",
                        column: x => x.KompetenzId,
                        principalTable: "Kompetenzen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ma_Technologien_Mitarbeiter_MitarbeiterId",
                        column: x => x.MitarbeiterId,
                        principalTable: "Mitarbeiter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ma_Technologien_Technologie_TechnologieId",
                        column: x => x.TechnologieId,
                        principalTable: "Technologie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Technologien_KompetenzId",
                table: "Ma_Technologien",
                column: "KompetenzId");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Technologien_MitarbeiterId",
                table: "Ma_Technologien",
                column: "MitarbeiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Technologien_TechnologieId",
                table: "Ma_Technologien",
                column: "TechnologieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ma_Technologien");
        }
    }
}
