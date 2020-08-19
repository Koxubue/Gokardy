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
                name: "Kierowca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false),
                    Wiek = table.Column<int>(nullable: false),
                    NumerKarty = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kierowca", x => x.Id);
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
                name: "Wlasciciel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: false),
                    Nazwisko = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wlasciciel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprzet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 50, nullable: false),
                    Koszt = table.Column<double>(nullable: false),
                    KierowcaId = table.Column<int>(nullable: true)
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
                name: "Tor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 100, nullable: false),
                    Dlugosc = table.Column<double>(nullable: false),
                    StawkaGodzinowa = table.Column<double>(nullable: false),
                    AdresId = table.Column<int>(nullable: false),
                    WlascicielId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tor_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tor_Wlasciciel_WlascicielId",
                        column: x => x.WlascicielId,
                        principalTable: "Wlasciciel",
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
                    TorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pracownik_Tor_TorId",
                        column: x => x.TorId,
                        principalTable: "Tor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Przejazd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Czas = table.Column<TimeSpan>(type: "time", nullable: false),
                    DataPrzejazdu = table.Column<DateTime>(type: "datetime", nullable: false),
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

            migrationBuilder.InsertData(
                table: "Adres",
                columns: new[] { "Id", "Miasto", "Panstwo", "Ulica" },
                values: new object[,]
                {
                    { 1, "Monza", "Włochy", "Viale di Vedano, 5" },
                    { 2, "Stavelot", "Belgia", "Route du Circuit 55" },
                    { 3, "Zandvoort", "Holandia", "Burgemeester van Alphenstraat 108" }
                });

            migrationBuilder.InsertData(
                table: "Kierowca",
                columns: new[] { "Id", "Imie", "Nazwisko", "NumerKarty", "Wiek" },
                values: new object[,]
                {
                    { 1, "Tomasz", "Kowalski", "k1704", 21 },
                    { 2, "Marcin", "Pędziwiatr", "k898", 16 },
                    { 3, "Jakub", "Mazur", "k19", 18 }
                });

            migrationBuilder.InsertData(
                table: "Nadwozie",
                columns: new[] { "Id", "Producent" },
                values: new object[,]
                {
                    { 1, "Alfa Romeo" },
                    { 2, "Honda" },
                    { 3, "Chevrolet" }
                });

            migrationBuilder.InsertData(
                table: "Podwozie",
                columns: new[] { "Id", "Producent" },
                values: new object[,]
                {
                    { 3, "Chevrolet" },
                    { 2, "Honda" },
                    { 1, "Alfa Romeo" }
                });

            migrationBuilder.InsertData(
                table: "Silnik",
                columns: new[] { "Id", "Moc", "Pojemnosc", "Producent" },
                values: new object[,]
                {
                    { 1, 20, 600, "Mercedes" },
                    { 2, 15, 350, "Audi" },
                    { 3, 25, 800, "Ferrari" }
                });

            migrationBuilder.InsertData(
                table: "Sponsor",
                columns: new[] { "Id", "Nazwa" },
                values: new object[,]
                {
                    { 1, "ORLEN" },
                    { 2, "STS" },
                    { 3, "PEKAO" }
                });

            migrationBuilder.InsertData(
                table: "Sprzet",
                columns: new[] { "Id", "KierowcaId", "Koszt", "Nazwa" },
                values: new object[] { 2, null, 15.0, "Rękawice czarne normalne" });

            migrationBuilder.InsertData(
                table: "Wlasciciel",
                columns: new[] { "Id", "Imie", "Nazwisko" },
                values: new object[,]
                {
                    { 1, "Wiktor", "Charitonin" },
                    { 2, "Gerard", "Lopez" }
                });

            migrationBuilder.InsertData(
                table: "KierowcaSponsor",
                columns: new[] { "KierowcaId", "SponsorId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sprzet",
                columns: new[] { "Id", "KierowcaId", "Koszt", "Nazwa" },
                values: new object[,]
                {
                    { 1, 1, 25.0, "Kask czerwony mały" },
                    { 3, 3, 10.0, "Kominiarka normalna" }
                });

            migrationBuilder.InsertData(
                table: "Tor",
                columns: new[] { "Id", "AdresId", "Dlugosc", "Nazwa", "StawkaGodzinowa", "WlascicielId" },
                values: new object[,]
                {
                    { 2, 2, 7.0039999999999996, "Circuit de Spa-Francorchamps", 450.0, 1 },
                    { 3, 3, 4.2519999999999998, "Circuit Zandvoort", 350.0, 1 },
                    { 1, 1, 5.7930000000000001, "Autodromo Nazionale di Monza", 400.0, 2 }
                });

            migrationBuilder.InsertData(
                table: "Gokard",
                columns: new[] { "Id", "NadwozieId", "Nazwa", "PodwozieId", "SilnikId", "TorId", "Waga" },
                values: new object[,]
                {
                    { 3, 3, "Standard+", 3, 3, 2, 180 },
                    { 1, 2, "Junior", 2, 2, 3, 150 },
                    { 2, 1, "Standard", 1, 1, 1, 160 }
                });

            migrationBuilder.InsertData(
                table: "Pracownik",
                columns: new[] { "Id", "Imie", "Nazwisko", "Stanowisko", "TorId", "Wiek", "Wynagrodzenie" },
                values: new object[,]
                {
                    { 2, "Robert", "Walczak", "Instruktor", 2, 31, 4500.0 },
                    { 3, "Krzysztof", "Błyskawica", "Kierownik toru", 3, 28, 5500.0 },
                    { 1, "Paweł", "Wójcik", "Recepcjonista", 1, 25, 3300.0 }
                });

            migrationBuilder.InsertData(
                table: "Przejazd",
                columns: new[] { "Id", "Czas", "DataPrzejazdu", "GokardId", "KierowcaId", "TorId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 0, 4, 25, 732), new DateTime(2020, 6, 18, 11, 33, 47, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 2, new TimeSpan(0, 0, 4, 27, 319), new DateTime(2019, 12, 20, 17, 2, 13, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 3, new TimeSpan(0, 0, 4, 25, 588), new DateTime(2019, 10, 13, 16, 45, 38, 0, DateTimeKind.Unspecified), 3, 1, 1 },
                    { 4, new TimeSpan(0, 0, 3, 59, 711), new DateTime(2020, 7, 18, 14, 7, 16, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 5, new TimeSpan(0, 0, 3, 59, 646), new DateTime(2020, 7, 18, 14, 12, 29, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 6, new TimeSpan(0, 0, 4, 2, 11), new DateTime(2018, 10, 23, 20, 0, 36, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 7, new TimeSpan(0, 0, 5, 38, 412), new DateTime(2019, 8, 30, 15, 56, 4, 0, DateTimeKind.Unspecified), 3, 3, 2 },
                    { 8, new TimeSpan(0, 0, 5, 41, 774), new DateTime(2019, 9, 16, 9, 14, 36, 0, DateTimeKind.Unspecified), 3, 3, 2 },
                    { 9, new TimeSpan(0, 0, 5, 37, 292), new DateTime(2020, 8, 17, 12, 37, 40, 0, DateTimeKind.Unspecified), 3, 3, 2 }
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
                name: "IX_KierowcaSponsor_SponsorId",
                table: "KierowcaSponsor",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pracownik_TorId",
                table: "Pracownik",
                column: "TorId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tor_WlascicielId",
                table: "Tor",
                column: "WlascicielId");
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
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Wlasciciel");
        }
    }
}
