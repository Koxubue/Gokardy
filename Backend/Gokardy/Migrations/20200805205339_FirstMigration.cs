using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gokardy.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Panstwo = table.Column<string>(maxLength: 50, nullable: false),
                    Miasto = table.Column<string>(maxLength: 50, nullable: false),
                    Ulica = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nadwozie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nadwozie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Podwozie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Producent = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Podwozie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Silnik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moc = table.Column<int>(nullable: false),
                    Pojemnosc = table.Column<int>(nullable: false),
                    Producent = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Silnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 30, nullable: false),
                    Haslo = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 100, nullable: false),
                    Długosc = table.Column<double>(nullable: false),
                    StawkaGodzinowa = table.Column<double>(nullable: false),
                    AdresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tor_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kierowca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Wiek = table.Column<int>(nullable: false),
                    NumerKarty = table.Column<string>(maxLength: 50, nullable: true),
                    UzytkownikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierowca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kierowca_Uzytkownik_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Gokard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
                    Waga = table.Column<int>(nullable: false),
                    SilnikId = table.Column<int>(nullable: false),
                    PodwozieId = table.Column<int>(nullable: false),
                    NadwozieId = table.Column<int>(nullable: false),
                    TorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gokard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gokard_Nadwozie_NadwozieId",
                        column: x => x.NadwozieId,
                        principalTable: "Nadwozie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gokard_Podwozie_PodwozieId",
                        column: x => x.PodwozieId,
                        principalTable: "Podwozie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gokard_Silnik_SilnikId",
                        column: x => x.SilnikId,
                        principalTable: "Silnik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Gokard_Tor_TorId",
                        column: x => x.TorId,
                        principalTable: "Tor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Wiek = table.Column<int>(nullable: false),
                    Stanowisko = table.Column<string>(maxLength: 50, nullable: true),
                    Wynagrodzenie = table.Column<double>(nullable: false),
                    TorId = table.Column<int>(nullable: false),
                    UzytkownikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pracownik_Tor_TorId",
                        column: x => x.TorId,
                        principalTable: "Tor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pracownik_Uzytkownik_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "Uzytkownik",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KierowcaSponsor",
                columns: table => new
                {
                    KierowcaId = table.Column<int>(nullable: false),
                    SponsorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KierowcaSponsor", x => new { x.KierowcaId, x.SponsorId });
                    table.ForeignKey(
                        name: "Kierowca_KierowcaSponsor",
                        column: x => x.KierowcaId,
                        principalTable: "Kierowca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Sponsor_KierowcaSponsor",
                        column: x => x.SponsorId,
                        principalTable: "Sponsor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprzet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
                    Koszt = table.Column<double>(nullable: false),
                    KierowcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprzet_Kierowca_KierowcaId",
                        column: x => x.KierowcaId,
                        principalTable: "Kierowca",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Przejazd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Czas = table.Column<DateTime>(type: "date", nullable: false),
                    GokardId = table.Column<int>(nullable: false),
                    TorId = table.Column<int>(nullable: false),
                    KierowcaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Przejazd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Przejazd_Gokard_GokardId",
                        column: x => x.GokardId,
                        principalTable: "Gokard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Przejazd_Kierowca_KierowcaId",
                        column: x => x.KierowcaId,
                        principalTable: "Kierowca",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Przejazd_Tor_TorId",
                        column: x => x.TorId,
                        principalTable: "Tor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gokard_NadwozieId",
                table: "Gokard",
                column: "NadwozieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gokard_PodwozieId",
                table: "Gokard",
                column: "PodwozieId");

            migrationBuilder.CreateIndex(
                name: "IX_Gokard_SilnikId",
                table: "Gokard",
                column: "SilnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Gokard_TorId",
                table: "Gokard",
                column: "TorId");

            migrationBuilder.CreateIndex(
                name: "IX_Kierowca_UzytkownikId",
                table: "Kierowca",
                column: "UzytkownikId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KierowcaSponsor_SponsorId",
                table: "KierowcaSponsor",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_TorId",
                table: "Pracownik",
                column: "TorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_UzytkownikId",
                table: "Pracownik",
                column: "UzytkownikId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Przejazd_GokardId",
                table: "Przejazd",
                column: "GokardId");

            migrationBuilder.CreateIndex(
                name: "IX_Przejazd_KierowcaId",
                table: "Przejazd",
                column: "KierowcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Przejazd_TorId",
                table: "Przejazd",
                column: "TorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprzet_KierowcaId",
                table: "Sprzet",
                column: "KierowcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tor_AdresId",
                table: "Tor",
                column: "AdresId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KierowcaSponsor");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropTable(
                name: "Przejazd");

            migrationBuilder.DropTable(
                name: "Sprzet");

            migrationBuilder.DropTable(
                name: "Sponsor");

            migrationBuilder.DropTable(
                name: "Gokard");

            migrationBuilder.DropTable(
                name: "Kierowca");

            migrationBuilder.DropTable(
                name: "Nadwozie");

            migrationBuilder.DropTable(
                name: "Podwozie");

            migrationBuilder.DropTable(
                name: "Silnik");

            migrationBuilder.DropTable(
                name: "Tor");

            migrationBuilder.DropTable(
                name: "Uzytkownik");

            migrationBuilder.DropTable(
                name: "Adres");
        }
    }
}
