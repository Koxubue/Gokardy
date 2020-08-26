using Microsoft.EntityFrameworkCore.Migrations;

namespace Gokardy.Migrations
{
    public partial class FifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Haslo",
                table: "Wlasciciel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Wlasciciel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Haslo",
                table: "Pracownik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Pracownik",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Haslo",
                table: "Kierowca",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Kierowca",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Haslo",
                table: "Wlasciciel");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Wlasciciel");

            migrationBuilder.DropColumn(
                name: "Haslo",
                table: "Pracownik");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Pracownik");

            migrationBuilder.DropColumn(
                name: "Haslo",
                table: "Kierowca");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Kierowca");
        }
    }
}
