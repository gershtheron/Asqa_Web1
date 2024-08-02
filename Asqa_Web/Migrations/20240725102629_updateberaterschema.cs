using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class updateberaterschema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /*  migrationBuilder.DropForeignKey(
                name: "FK_Berater_Projekt_Taetigkeit_Taetigkeiten_TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit");

            migrationBuilder.AlterColumn<int>(
                name: "TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

           migrationBuilder.CreateTable(
                name: "Projekt_Technologie",
                columns: table => new
                {
                    ProjektId = table.Column<int>(type: "int", nullable: false),
                    TechnologieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt_Technologie", x => new { x.ProjektId, x.TechnologieId });
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
                name: "IX_Projekt_Technologie_TechnologieId",
                table: "Projekt_Technologie",
                column: "TechnologieId");*/

            migrationBuilder.AddForeignKey(
                name: "FK_Berater_Projekt_Taetigkeit_Taetigkeiten_TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit",
                column: "TaetigkeitId",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berater_Projekt_Taetigkeit_Taetigkeiten_TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit");

            migrationBuilder.DropTable(
                name: "Projekt_Technologie");

            migrationBuilder.AlterColumn<int>(
                name: "TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Berater_Projekt_Taetigkeit_Taetigkeiten_TaetigkeitId",
                table: "Berater_Projekt_Taetigkeit",
                column: "TaetigkeitId",
                principalTable: "Taetigkeiten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
