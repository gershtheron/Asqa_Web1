using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class addrolleidtoberaterprojekten : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berater_Projekten_Mitarbeiter_MitarbeiterId",
                table: "Berater_Projekten");

            migrationBuilder.AlterColumn<Guid>(
                name: "MitarbeiterId",
                table: "Berater_Projekten",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "RolleId",
                table: "Berater_Projekten",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Berater_Projekten_RolleId",
                table: "Berater_Projekten",
                column: "RolleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Berater_Projekten_Mitarbeiter_MitarbeiterId",
                table: "Berater_Projekten",
                column: "MitarbeiterId",
                principalTable: "Mitarbeiter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Berater_Projekten_Rollen_RolleId",
                table: "Berater_Projekten",
                column: "RolleId",
                principalTable: "Rollen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Berater_Projekten_Mitarbeiter_MitarbeiterId",
                table: "Berater_Projekten");

            migrationBuilder.DropForeignKey(
                name: "FK_Berater_Projekten_Rollen_RolleId",
                table: "Berater_Projekten");

            migrationBuilder.DropIndex(
                name: "IX_Berater_Projekten_RolleId",
                table: "Berater_Projekten");

            migrationBuilder.DropColumn(
                name: "RolleId",
                table: "Berater_Projekten");

            migrationBuilder.AlterColumn<Guid>(
                name: "MitarbeiterId",
                table: "Berater_Projekten",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Berater_Projekten_Mitarbeiter_MitarbeiterId",
                table: "Berater_Projekten",
                column: "MitarbeiterId",
                principalTable: "Mitarbeiter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
