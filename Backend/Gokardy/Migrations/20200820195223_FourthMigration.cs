using Microsoft.EntityFrameworkCore.Migrations;

namespace Gokardy.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "PersonalizowanyGokard");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "PersonalizowanyGokard",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
