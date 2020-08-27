using Microsoft.EntityFrameworkCore.Migrations;

namespace Gokardy.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sol",
                table: "Wlasciciel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sol",
                table: "Pracownik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sol",
                table: "Kierowca",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sol",
                table: "Wlasciciel");

            migrationBuilder.DropColumn(
                name: "Sol",
                table: "Pracownik");

            migrationBuilder.DropColumn(
                name: "Sol",
                table: "Kierowca");
        }
    }
}
