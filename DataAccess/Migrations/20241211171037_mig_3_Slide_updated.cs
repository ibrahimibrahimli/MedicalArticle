using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_3_Slide_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Slides",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slides_Languages_LanguageId",
                table: "Slides",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slides_Languages_LanguageId",
                table: "Slides");

            migrationBuilder.DropIndex(
                name: "IX_Slides_LanguageId",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Slides");
        }
    }
}
