using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_sosial_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sosials_Languages_LanguageId",
                table: "Sosials");

            migrationBuilder.DropIndex(
                name: "IX_Sosials_LanguageId",
                table: "Sosials");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Sosials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Sosials",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
