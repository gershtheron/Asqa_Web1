using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class taetigkeitserse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.RenameColumn(
                name: "Taetigkeiten",
                table: "Ma_Projekte",
                newName: "TaetigkeitenDescriptions");

            migrationBuilder.AddColumn<int>(
                name: "Taetigkeit1",
                table: "Ma_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taetigkeit2",
                table: "Ma_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taetigkeit3",
                table: "Ma_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taetigkeit4",
                table: "Ma_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taetigkeit5",
                table: "Ma_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Taetigkeit6",
                table: "Ma_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Projekte_Taetigkeit1",
                table: "Ma_Projekte",
                column: "Taetigkeit1");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Projekte_Taetigkeit2",
                table: "Ma_Projekte",
                column: "Taetigkeit2");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Projekte_Taetigkeit3",
                table: "Ma_Projekte",
                column: "Taetigkeit3");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Projekte_Taetigkeit4",
                table: "Ma_Projekte",
                column: "Taetigkeit4");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Projekte_Taetigkeit5",
                table: "Ma_Projekte",
                column: "Taetigkeit5");

            migrationBuilder.CreateIndex(
                name: "IX_Ma_Projekte_Taetigkeit6",
                table: "Ma_Projekte",
                column: "Taetigkeit6");

            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit1",
                table: "Ma_Projekte",
                column: "Taetigkeit1",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit2",
                table: "Ma_Projekte",
                column: "Taetigkeit2",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit3",
                table: "Ma_Projekte",
                column: "Taetigkeit3",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit4",
                table: "Ma_Projekte",
                column: "Taetigkeit4",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit5",
                table: "Ma_Projekte",
                column: "Taetigkeit5",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit6",
                table: "Ma_Projekte",
                column: "Taetigkeit6",
                principalTable: "Taetigkeiten",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit1",
                table: "Ma_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit2",
                table: "Ma_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit3",
                table: "Ma_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit4",
                table: "Ma_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit5",
                table: "Ma_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Taetigkeiten_Taetigkeit6",
                table: "Ma_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_Taetigkeit1",
                table: "Ma_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_Taetigkeit2",
                table: "Ma_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_Taetigkeit3",
                table: "Ma_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_Taetigkeit4",
                table: "Ma_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_Taetigkeit5",
                table: "Ma_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_Taetigkeit6",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "Taetigkeit1",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "Taetigkeit2",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "Taetigkeit3",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "Taetigkeit4",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "Taetigkeit5",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "Taetigkeit6",
                table: "Ma_Projekte");

            migrationBuilder.RenameColumn(
                name: "TaetigkeitenDescriptions",
                table: "Ma_Projekte",
                newName: "Taetigkeiten");*/
        }
    }
}
