using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class updatemitarprokektrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.DropForeignKey(
                name: "FK_Mitarb_Projekte_Mitarbeiter_MitarbeiterId",
                table: "Mitarb_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Mitarb_Projekte_Projekten_ProjektenId",
                table: "Mitarb_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Mitarb_Projekte_MitarbeiterId",
                table: "Mitarb_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Mitarb_Projekte_ProjektenId",
                table: "Mitarb_Projekte");

            migrationBuilder.DropColumn(
                name: "MitarbeiterId",
                table: "Mitarb_Projekte");

            migrationBuilder.DropColumn(
                name: "ProjektenId",
                table: "Mitarb_Projekte");

            migrationBuilder.AlterColumn<Guid>(
                name: "Ma_id",
                table: "Mitarb_Projekte",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Mitarb_Projekte_Ma_id",
                table: "Mitarb_Projekte",
                column: "Ma_id");

            migrationBuilder.CreateIndex(
                name: "IX_Mitarb_Projekte_Proj_id",
                table: "Mitarb_Projekte",
                column: "Proj_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mitarb_Projekte_Mitarbeiter_Ma_id",
                table: "Mitarb_Projekte",
                column: "Ma_id",
                principalTable: "Mitarbeiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mitarb_Projekte_Projekten_Proj_id",
                table: "Mitarb_Projekte",
                column: "Proj_id",
                principalTable: "Projekten",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mitarb_Projekte_Mitarbeiter_Ma_id",
                table: "Mitarb_Projekte");

            migrationBuilder.DropForeignKey(
                name: "FK_Mitarb_Projekte_Projekten_Proj_id",
                table: "Mitarb_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Mitarb_Projekte_Ma_id",
                table: "Mitarb_Projekte");

            migrationBuilder.DropIndex(
                name: "IX_Mitarb_Projekte_Proj_id",
                table: "Mitarb_Projekte");

            migrationBuilder.AlterColumn<int>(
                name: "Ma_id",
                table: "Mitarb_Projekte",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "MitarbeiterId",
                table: "Mitarb_Projekte",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "ProjektenId",
                table: "Mitarb_Projekte",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mitarb_Projekte_MitarbeiterId",
                table: "Mitarb_Projekte",
                column: "MitarbeiterId");

            migrationBuilder.CreateIndex(
                name: "IX_Mitarb_Projekte_ProjektenId",
                table: "Mitarb_Projekte",
                column: "ProjektenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mitarb_Projekte_Mitarbeiter_MitarbeiterId",
                table: "Mitarb_Projekte",
                column: "MitarbeiterId",
                principalTable: "Mitarbeiter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mitarb_Projekte_Projekten_ProjektenId",
                table: "Mitarb_Projekte",
                column: "ProjektenId",
                principalTable: "Projekten",
                principalColumn: "Id"); */
        }
    }
}
