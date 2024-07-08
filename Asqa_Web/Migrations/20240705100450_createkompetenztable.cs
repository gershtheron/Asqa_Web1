using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asqa_Web.Migrations
{
    /// <inheritdoc />
    public partial class createkompetenztable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            

            migrationBuilder.CreateTable(
                name: "Kompetenzen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Komp_name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompetenzen", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Kompetenzen",
                columns: new[] { "Id", "Komp_name" },
                values: new object[,]
                {
                    { 1, "Muttersprache" },
                    { 2, "Sehr Gut" },
                    { 3, "Gut" },
                    { 4, "Grundkenntnisse" },
                    { 5, "Fortgeschritten" },
                    { 6, "Expertenkenntnisse" }
                });

          
            migrationBuilder.AddForeignKey(
                name: "FK_Ma_Projekte_Rollen_RolleId",
                table: "Ma_Projekte",
                column: "RolleId",
                principalTable: "Rollen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ma_Projekte_Rollen_RolleId",
                table: "Ma_Projekte");

            migrationBuilder.DropTable(
                name: "Kompetenzen");

            migrationBuilder.DropIndex(
                name: "IX_Ma_Projekte_RolleId",
                table: "Ma_Projekte");

            migrationBuilder.DropColumn(
                name: "RolleId",
                table: "Ma_Projekte");

            migrationBuilder.AddColumn<string>(
                name: "Rolle",
                table: "Ma_Projekte",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}