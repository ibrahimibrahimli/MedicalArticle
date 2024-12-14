using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_4_Entities_added_LanguageId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Faqs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Facts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Adresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Faqs_LanguageId",
                table: "Faqs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Facts_LanguageId",
                table: "Facts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_LanguageId",
                table: "Blogs",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_LanguageId",
                table: "Adresses",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Languages_LanguageId",
                table: "Adresses",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Languages_LanguageId",
                table: "Blogs",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facts_Languages_LanguageId",
                table: "Facts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faqs_Languages_LanguageId",
                table: "Faqs",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Languages_LanguageId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Languages_LanguageId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Facts_Languages_LanguageId",
                table: "Facts");

            migrationBuilder.DropForeignKey(
                name: "FK_Faqs_Languages_LanguageId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Faqs_LanguageId",
                table: "Faqs");

            migrationBuilder.DropIndex(
                name: "IX_Facts_LanguageId",
                table: "Facts");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_LanguageId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_LanguageId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Adresses");
        }
    }
}
