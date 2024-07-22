using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class addprojektentechnologierelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropPrimaryKey(
                name: "PK_Projekt_Technologie",
                table: "Projekt_Technologie");

           migrationBuilder.DropIndex(
                name: "IX_Projekt_Technologie_ProjektId",
                table: "Projekt_Technologie");*/

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projekt_Technologie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projekt_Technologie",
                table: "Projekt_Technologie",
                columns: new[] { "ProjektId", "TechnologieId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
         /*   migrationBuilder.DropPrimaryKey(
                name: "PK_Projekt_Technologie",
                table: "Projekt_Technologie");*/

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projekt_Technologie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projekt_Technologie",
                table: "Projekt_Technologie",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projekt_Technologie_ProjektId",
                table: "Projekt_Technologie",
                column: "ProjektId");
        }
    }
}
