using Microsoft.EntityFrameworkCore.Migrations;

namespace Gokardy.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "Silnik",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Waga",
                table: "Silnik",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "Podwozie",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Waga",
                table: "Podwozie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "Nadwozie",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Waga",
                table: "Nadwozie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "Gokard",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Gokard",
                keyColumn: "Id",
                keyValue: 1,
                column: "Cena",
                value: 2000.0);

            migrationBuilder.UpdateData(
                table: "Gokard",
                keyColumn: "Id",
                keyValue: 2,
                column: "Cena",
                value: 3000.0);

            migrationBuilder.UpdateData(
                table: "Gokard",
                keyColumn: "Id",
                keyValue: 3,
                column: "Cena",
                value: 4000.0);

            migrationBuilder.UpdateData(
                table: "Nadwozie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 300.0, 100 });

            migrationBuilder.UpdateData(
                table: "Nadwozie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 400.0, 200 });

            migrationBuilder.UpdateData(
                table: "Nadwozie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 400.0, 300 });

            migrationBuilder.UpdateData(
                table: "Podwozie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 300.0, 100 });

            migrationBuilder.UpdateData(
                table: "Podwozie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 700.0, 400 });

            migrationBuilder.UpdateData(
                table: "Podwozie",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 100.0, 300 });

            migrationBuilder.UpdateData(
                table: "Silnik",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 300.0, 700 });

            migrationBuilder.UpdateData(
                table: "Silnik",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 800.0, 600 });

            migrationBuilder.UpdateData(
                table: "Silnik",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cena", "Waga" },
                values: new object[] { 900.0, 500 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Silnik");

            migrationBuilder.DropColumn(
                name: "Waga",
                table: "Silnik");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Podwozie");

            migrationBuilder.DropColumn(
                name: "Waga",
                table: "Podwozie");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Nadwozie");

            migrationBuilder.DropColumn(
                name: "Waga",
                table: "Nadwozie");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Gokard");
        }
    }
}
