﻿// <auto-generated />
using System;
using Gokardy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gokardy.Migrations
{
    [DbContext(typeof(GokardyContext))]
    partial class GokardyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gokardy.Models.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Miasto")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Panstwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ulica")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Adres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Miasto = "Monza",
                            Panstwo = "Włochy",
                            Ulica = "Viale di Vedano, 5"
                        },
                        new
                        {
                            Id = 2,
                            Miasto = "Stavelot",
                            Panstwo = "Belgia",
                            Ulica = "Route du Circuit 55"
                        },
                        new
                        {
                            Id = 3,
                            Miasto = "Zandvoort",
                            Panstwo = "Holandia",
                            Ulica = "Burgemeester van Alphenstraat 108"
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Gokard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("NadwozieId")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("PodwozieId")
                        .HasColumnType("int");

                    b.Property<int>("SilnikId")
                        .HasColumnType("int");

                    b.Property<int>("TorId")
                        .HasColumnType("int");

                    b.Property<int>("Waga")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NadwozieId");

                    b.HasIndex("PodwozieId");

                    b.HasIndex("SilnikId");

                    b.HasIndex("TorId");

                    b.ToTable("Gokard");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 2000.0,
                            NadwozieId = 2,
                            Nazwa = "Junior",
                            PodwozieId = 2,
                            SilnikId = 2,
                            TorId = 3,
                            Waga = 150
                        },
                        new
                        {
                            Id = 2,
                            Cena = 3000.0,
                            NadwozieId = 1,
                            Nazwa = "Standard",
                            PodwozieId = 1,
                            SilnikId = 1,
                            TorId = 1,
                            Waga = 160
                        },
                        new
                        {
                            Id = 3,
                            Cena = 4000.0,
                            NadwozieId = 3,
                            Nazwa = "Standard+",
                            PodwozieId = 3,
                            SilnikId = 3,
                            TorId = 2,
                            Waga = 180
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Kierowca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Haslo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumerKarty")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Sol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wiek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Kierowca");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Imie = "Tomasz",
                            Nazwisko = "Kowalski",
                            NumerKarty = "k1704",
                            Wiek = 21
                        },
                        new
                        {
                            Id = 2,
                            Imie = "Marcin",
                            Nazwisko = "Pędziwiatr",
                            NumerKarty = "k898",
                            Wiek = 16
                        },
                        new
                        {
                            Id = 3,
                            Imie = "Jakub",
                            Nazwisko = "Mazur",
                            NumerKarty = "k19",
                            Wiek = 18
                        });
                });

            modelBuilder.Entity("Gokardy.Models.KierowcaSponsor", b =>
                {
                    b.Property<int>("KierowcaId")
                        .HasColumnType("int");

                    b.Property<int>("SponsorId")
                        .HasColumnType("int");

                    b.HasKey("KierowcaId", "SponsorId");

                    b.HasIndex("SponsorId");

                    b.ToTable("KierowcaSponsor");

                    b.HasData(
                        new
                        {
                            KierowcaId = 1,
                            SponsorId = 2
                        },
                        new
                        {
                            KierowcaId = 2,
                            SponsorId = 1
                        },
                        new
                        {
                            KierowcaId = 3,
                            SponsorId = 3
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Nadwozie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Producent")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Waga")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Nadwozie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 300.0,
                            Producent = "Alfa Romeo",
                            Waga = 100
                        },
                        new
                        {
                            Id = 2,
                            Cena = 400.0,
                            Producent = "Honda",
                            Waga = 200
                        },
                        new
                        {
                            Id = 3,
                            Cena = 400.0,
                            Producent = "Chevrolet",
                            Waga = 300
                        });
                });

            modelBuilder.Entity("Gokardy.Models.PersonalizowanyGokard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GokardId")
                        .HasColumnType("int");

                    b.Property<int>("KierowcaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GokardId")
                        .IsUnique();

                    b.HasIndex("KierowcaId");

                    b.ToTable("PersonalizowanyGokard");
                });

            modelBuilder.Entity("Gokardy.Models.Podwozie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Producent")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Waga")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Podwozie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 300.0,
                            Producent = "Alfa Romeo",
                            Waga = 100
                        },
                        new
                        {
                            Id = 2,
                            Cena = 700.0,
                            Producent = "Honda",
                            Waga = 400
                        },
                        new
                        {
                            Id = 3,
                            Cena = 100.0,
                            Producent = "Chevrolet",
                            Waga = 300
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Pracownik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Haslo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stanowisko")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("TorId")
                        .HasColumnType("int");

                    b.Property<int>("Wiek")
                        .HasColumnType("int");

                    b.Property<double>("Wynagrodzenie")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TorId");

                    b.ToTable("Pracownik");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Imie = "Paweł",
                            Nazwisko = "Wójcik",
                            Stanowisko = "Recepcjonista",
                            TorId = 1,
                            Wiek = 25,
                            Wynagrodzenie = 3300.0
                        },
                        new
                        {
                            Id = 2,
                            Imie = "Robert",
                            Nazwisko = "Walczak",
                            Stanowisko = "Instruktor",
                            TorId = 2,
                            Wiek = 31,
                            Wynagrodzenie = 4500.0
                        },
                        new
                        {
                            Id = 3,
                            Imie = "Krzysztof",
                            Nazwisko = "Błyskawica",
                            Stanowisko = "Kierownik toru",
                            TorId = 3,
                            Wiek = 28,
                            Wynagrodzenie = 5500.0
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Przejazd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Czas")
                        .HasColumnType("time");

                    b.Property<DateTime>("DataPrzejazdu")
                        .HasColumnType("datetime");

                    b.Property<int>("GokardId")
                        .HasColumnType("int");

                    b.Property<int>("KierowcaId")
                        .HasColumnType("int");

                    b.Property<int>("TorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GokardId");

                    b.HasIndex("KierowcaId");

                    b.HasIndex("TorId");

                    b.ToTable("Przejazd");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Czas = new TimeSpan(0, 0, 4, 25, 732),
                            DataPrzejazdu = new DateTime(2020, 6, 18, 11, 33, 47, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 1,
                            TorId = 1
                        },
                        new
                        {
                            Id = 2,
                            Czas = new TimeSpan(0, 0, 4, 27, 319),
                            DataPrzejazdu = new DateTime(2019, 12, 20, 17, 2, 13, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 1,
                            TorId = 1
                        },
                        new
                        {
                            Id = 3,
                            Czas = new TimeSpan(0, 0, 4, 25, 588),
                            DataPrzejazdu = new DateTime(2019, 10, 13, 16, 45, 38, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 1,
                            TorId = 1
                        },
                        new
                        {
                            Id = 4,
                            Czas = new TimeSpan(0, 0, 3, 59, 711),
                            DataPrzejazdu = new DateTime(2020, 7, 18, 14, 7, 16, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 2,
                            TorId = 3
                        },
                        new
                        {
                            Id = 5,
                            Czas = new TimeSpan(0, 0, 3, 59, 646),
                            DataPrzejazdu = new DateTime(2020, 7, 18, 14, 12, 29, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 2,
                            TorId = 3
                        },
                        new
                        {
                            Id = 6,
                            Czas = new TimeSpan(0, 0, 4, 2, 11),
                            DataPrzejazdu = new DateTime(2018, 10, 23, 20, 0, 36, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 2,
                            TorId = 3
                        },
                        new
                        {
                            Id = 7,
                            Czas = new TimeSpan(0, 0, 5, 38, 412),
                            DataPrzejazdu = new DateTime(2019, 8, 30, 15, 56, 4, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 3,
                            TorId = 2
                        },
                        new
                        {
                            Id = 8,
                            Czas = new TimeSpan(0, 0, 5, 41, 774),
                            DataPrzejazdu = new DateTime(2019, 9, 16, 9, 14, 36, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 3,
                            TorId = 2
                        },
                        new
                        {
                            Id = 9,
                            Czas = new TimeSpan(0, 0, 5, 37, 292),
                            DataPrzejazdu = new DateTime(2020, 8, 17, 12, 37, 40, 0, DateTimeKind.Unspecified),
                            GokardId = 3,
                            KierowcaId = 3,
                            TorId = 2
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Silnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<int>("Moc")
                        .HasColumnType("int");

                    b.Property<int>("Pojemnosc")
                        .HasColumnType("int");

                    b.Property<string>("Producent")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Waga")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Silnik");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cena = 300.0,
                            Moc = 20,
                            Pojemnosc = 600,
                            Producent = "Mercedes",
                            Waga = 700
                        },
                        new
                        {
                            Id = 2,
                            Cena = 800.0,
                            Moc = 15,
                            Pojemnosc = 350,
                            Producent = "Audi",
                            Waga = 600
                        },
                        new
                        {
                            Id = 3,
                            Cena = 900.0,
                            Moc = 25,
                            Pojemnosc = 800,
                            Producent = "Ferrari",
                            Waga = 500
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Sponsor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sponsor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nazwa = "ORLEN"
                        },
                        new
                        {
                            Id = 2,
                            Nazwa = "STS"
                        },
                        new
                        {
                            Id = 3,
                            Nazwa = "PEKAO"
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Sprzet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("KierowcaId")
                        .HasColumnType("int");

                    b.Property<double>("Koszt")
                        .HasColumnType("float");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("KierowcaId");

                    b.ToTable("Sprzet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            KierowcaId = 1,
                            Koszt = 25.0,
                            Nazwa = "Kask czerwony mały"
                        },
                        new
                        {
                            Id = 2,
                            Koszt = 15.0,
                            Nazwa = "Rękawice czarne normalne"
                        },
                        new
                        {
                            Id = 3,
                            KierowcaId = 3,
                            Koszt = 10.0,
                            Nazwa = "Kominiarka normalna"
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Tor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<double>("Dlugosc")
                        .HasColumnType("float");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("StawkaGodzinowa")
                        .HasColumnType("float");

                    b.Property<int>("WlascicielId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdresId")
                        .IsUnique();

                    b.HasIndex("WlascicielId");

                    b.ToTable("Tor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AdresId = 1,
                            Dlugosc = 5.7930000000000001,
                            Nazwa = "Autodromo Nazionale di Monza",
                            StawkaGodzinowa = 400.0,
                            WlascicielId = 2
                        },
                        new
                        {
                            Id = 2,
                            AdresId = 2,
                            Dlugosc = 7.0039999999999996,
                            Nazwa = "Circuit de Spa-Francorchamps",
                            StawkaGodzinowa = 450.0,
                            WlascicielId = 1
                        },
                        new
                        {
                            Id = 3,
                            AdresId = 3,
                            Dlugosc = 4.2519999999999998,
                            Nazwa = "Circuit Zandvoort",
                            StawkaGodzinowa = 350.0,
                            WlascicielId = 1
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Wlasciciel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Haslo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wlasciciel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Imie = "Wiktor",
                            Nazwisko = "Charitonin"
                        },
                        new
                        {
                            Id = 2,
                            Imie = "Gerard",
                            Nazwisko = "Lopez"
                        });
                });

            modelBuilder.Entity("Gokardy.Models.Gokard", b =>
                {
                    b.HasOne("Gokardy.Models.Nadwozie", "Nadwozie")
                        .WithMany("Gokard")
                        .HasForeignKey("NadwozieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Podwozie", "Podwozie")
                        .WithMany("Gokard")
                        .HasForeignKey("PodwozieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Silnik", "Silnik")
                        .WithMany("Gokard")
                        .HasForeignKey("SilnikId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Tor", "Tor")
                        .WithMany("Gokard")
                        .HasForeignKey("TorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Gokardy.Models.KierowcaSponsor", b =>
                {
                    b.HasOne("Gokardy.Models.Kierowca", "Kierowca")
                        .WithMany("KierowcaSponsor")
                        .HasForeignKey("KierowcaId")
                        .HasConstraintName("Kierowca_KierowcaSponsor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Sponsor", "Sponsor")
                        .WithMany("KierowcaSponsor")
                        .HasForeignKey("SponsorId")
                        .HasConstraintName("Sponsor_KierowcaSponsor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gokardy.Models.PersonalizowanyGokard", b =>
                {
                    b.HasOne("Gokardy.Models.Gokard", "Gokard")
                        .WithOne("PersonalizowanyGokard")
                        .HasForeignKey("Gokardy.Models.PersonalizowanyGokard", "GokardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Kierowca", "Kierowca")
                        .WithMany("PersonalizowanyGokard")
                        .HasForeignKey("KierowcaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Gokardy.Models.Pracownik", b =>
                {
                    b.HasOne("Gokardy.Models.Tor", "Tor")
                        .WithMany("Pracownik")
                        .HasForeignKey("TorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Gokardy.Models.Przejazd", b =>
                {
                    b.HasOne("Gokardy.Models.Gokard", "Gokard")
                        .WithMany("Przejazd")
                        .HasForeignKey("GokardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Kierowca", "Kierowca")
                        .WithMany("Przejazd")
                        .HasForeignKey("KierowcaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Tor", "Tor")
                        .WithMany("Przejazd")
                        .HasForeignKey("TorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Gokardy.Models.Sprzet", b =>
                {
                    b.HasOne("Gokardy.Models.Kierowca", "Kierowca")
                        .WithMany("Sprzet")
                        .HasForeignKey("KierowcaId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Gokardy.Models.Tor", b =>
                {
                    b.HasOne("Gokardy.Models.Adres", "Adres")
                        .WithOne("Tor")
                        .HasForeignKey("Gokardy.Models.Tor", "AdresId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gokardy.Models.Wlasciciel", "Wlasciciel")
                        .WithMany("Tor")
                        .HasForeignKey("WlascicielId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
