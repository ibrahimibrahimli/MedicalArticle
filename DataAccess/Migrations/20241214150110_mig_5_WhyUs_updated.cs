using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_5_WhyUs_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "WhyChooseUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "TeamBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Sosials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WhyChooseUs_LanguageId",
                table: "WhyChooseUs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamBoards_LanguageId",
                table: "TeamBoards",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sosials_LanguageId",
                table: "Sosials",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sosials_Languages_LanguageId",
                table: "Sosials",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamBoards_Languages_LanguageId",
                table: "TeamBoards",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WhyChooseUs_Languages_LanguageId",
                table: "WhyChooseUs",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sosials_Languages_LanguageId",
                table: "Sosials");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamBoards_Languages_LanguageId",
                table: "TeamBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_WhyChooseUs_Languages_LanguageId",
                table: "WhyChooseUs");

            migrationBuilder.DropIndex(
                name: "IX_WhyChooseUs_LanguageId",
                table: "WhyChooseUs");

            migrationBuilder.DropIndex(
                name: "IX_TeamBoards_LanguageId",
                table: "TeamBoards");

            migrationBuilder.DropIndex(
                name: "IX_Sosials_LanguageId",
                table: "Sosials");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "WhyChooseUs");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "TeamBoards");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Sosials");
        }
    }
}
