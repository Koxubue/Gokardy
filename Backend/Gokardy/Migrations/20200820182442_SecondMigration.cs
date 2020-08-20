using Microsoft.EntityFrameworkCore.Migrations;

namespace Gokardy.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalizowanyGokard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cena = table.Column<double>(nullable: false),
                    KierowcaId = table.Column<int>(nullable: false),
                    GokardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalizowanyGokard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalizowanyGokard_Gokard_GokardId",
                        column: x => x.GokardId,
                        principalTable: "Gokard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonalizowanyGokard_Kierowca_KierowcaId",
                        column: x => x.KierowcaId,
                        principalTable: "Kierowca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalizowanyGokard_GokardId",
                table: "PersonalizowanyGokard",
                column: "GokardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalizowanyGokard_KierowcaId",
                table: "PersonalizowanyGokard",
                column: "KierowcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalizowanyGokard");
        }
    }
}
