using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class mitarb_projekte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          /* migrationBuilder.AlterColumn<string>(
                name: "Tech_name",
                table: "Technologie",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Taetigkeiten",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Sprache_name",
                table: "Sprache",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Rolle_name",
                table: "Rollen",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mitarb_Projekte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ma_id = table.Column<int>(type: "int", nullable: false),
                    Proj_id = table.Column<int>(type: "int", nullable: false),
                    Ma_rolle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Start_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Proj_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Taetigkeiten = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MitarbeiterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ProjektenId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mitarb_Projekte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mitarb_Projekte_Mitarbeiter_MitarbeiterId",
                        column: x => x.MitarbeiterId,
                        principalTable: "Mitarbeiter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mitarb_Projekte_Projekten_ProjektenId",
                        column: x => x.ProjektenId,
                        principalTable: "Projekten",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Mitarb_Projekte_MitarbeiterId",
                table: "Mitarb_Projekte",
                column: "MitarbeiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Mitarb_Projekte_ProjektenId",
                table: "Mitarb_Projekte",
                column: "ProjektenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mitarb_Projekte");

            migrationBuilder.UpdateData(
                table: "Technologie",
                keyColumn: "Tech_name",
                keyValue: null,
                column: "Tech_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Tech_name",
                table: "Technologie",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Taetigkeiten",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Taetigkeiten",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Sprache",
                keyColumn: "Sprache_name",
                keyValue: null,
                column: "Sprache_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Sprache_name",
                table: "Sprache",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Rollen",
                keyColumn: "Rolle_name",
                keyValue: null,
                column: "Rolle_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Rolle_name",
                table: "Rollen",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4"); */
        }
    }
}
