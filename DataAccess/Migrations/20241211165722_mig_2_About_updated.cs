using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_About_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_LanguageId",
                table: "Abouts",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_Languages_LanguageId",
                table: "Abouts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_Languages_LanguageId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_LanguageId",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Abouts");
        }
    }
}
