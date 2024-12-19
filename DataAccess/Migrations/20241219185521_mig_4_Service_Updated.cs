using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_4_Service_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "WhyChooseUsItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "WhyChooseUs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Sosials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Slides",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "ServiceAbouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "ServiceAboutItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "HealtTips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "HealtTipItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Faqs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Facts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Adresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHomePage",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "WhyChooseUsItems");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "WhyChooseUs");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Sosials");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Slides");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "ServiceAbouts");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "ServiceAboutItems");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "HealtTips");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "HealtTipItems");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Facts");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "IsHomePage",
                table: "Abouts");
        }
    }
}
