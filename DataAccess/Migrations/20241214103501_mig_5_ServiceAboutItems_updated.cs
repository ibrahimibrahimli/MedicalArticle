using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_5_ServiceAboutItems_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ServiceAbouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ServiceAboutItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "HealtTips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "HealtTipItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceAboutItemsDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceAboutId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceAboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceAboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceAboutPhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceAboutItemsDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceAboutItemsDto_ServiceAbouts_ServiceAboutId",
                        column: x => x.ServiceAboutId,
                        principalTable: "ServiceAbouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_LanguageId",
                table: "Services",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAbouts_LanguageId",
                table: "ServiceAbouts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAboutItems_LanguageId",
                table: "ServiceAboutItems",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HealtTips_LanguageId",
                table: "HealtTips",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_HealtTipItems_LanguageId",
                table: "HealtTipItems",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceAboutItemsDto_ServiceAboutId",
                table: "ServiceAboutItemsDto",
                column: "ServiceAboutId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealtTipItems_Languages_LanguageId",
                table: "HealtTipItems",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealtTips_Languages_LanguageId",
                table: "HealtTips",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAboutItems_Languages_LanguageId",
                table: "ServiceAboutItems",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceAbouts_Languages_LanguageId",
                table: "ServiceAbouts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Languages_LanguageId",
                table: "Services",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealtTipItems_Languages_LanguageId",
                table: "HealtTipItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HealtTips_Languages_LanguageId",
                table: "HealtTips");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAboutItems_Languages_LanguageId",
                table: "ServiceAboutItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceAbouts_Languages_LanguageId",
                table: "ServiceAbouts");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Languages_LanguageId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceAboutItemsDto");

            migrationBuilder.DropIndex(
                name: "IX_Services_LanguageId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAbouts_LanguageId",
                table: "ServiceAbouts");

            migrationBuilder.DropIndex(
                name: "IX_ServiceAboutItems_LanguageId",
                table: "ServiceAboutItems");

            migrationBuilder.DropIndex(
                name: "IX_HealtTips_LanguageId",
                table: "HealtTips");

            migrationBuilder.DropIndex(
                name: "IX_HealtTipItems_LanguageId",
                table: "HealtTipItems");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ServiceAbouts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ServiceAboutItems");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "HealtTips");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "HealtTipItems");
        }
    }
}
