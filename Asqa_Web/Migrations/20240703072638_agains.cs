using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class agains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Proj_Name",
                table: "Ma_Projekte",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ma_Projekte",
                keyColumn: "Proj_Name",
                keyValue: null,
                column: "Proj_Name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Proj_Name",
                table: "Ma_Projekte",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
