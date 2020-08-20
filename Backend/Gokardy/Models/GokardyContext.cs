using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gokardy.Models
{
    public class GokardyContext : DbContext
    {
        public DbSet<Adres> Adres { get; set; }
        public DbSet<Gokard> Gokard { get; set; }
        public DbSet<Kierowca> Kierowca { get; set; }
        public DbSet<KierowcaSponsor> KierowcaSponsor { get; set; }
        public DbSet<Nadwozie> Nadwozie { get; set; }
        public DbSet<Podwozie> Podwozie { get; set; }
        public DbSet<Pracownik> Pracownik { get; set; }
        public DbSet<Przejazd> Przejazd { get; set; }
        public DbSet<Silnik> Silnik { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<Sprzet> Sprzet { get; set; }
        public DbSet<Tor> Tor { get; set; }
        public DbSet<Wlasciciel> Wlasciciel { get; set; }
        public DbSet<PersonalizowanyGokard> PersonalizowanyGokard { get; set; }


        public GokardyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.Id );
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Panstwo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Miasto).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Ulica).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Tor).WithOne(d => d.Adres).HasForeignKey<Tor>(e => e.AdresId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Gokard>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nazwa).IsRequired().HasMaxLength(50);                
                entity.HasOne(e => e.Podwozie).WithMany(d => d.Gokard).HasForeignKey(e => e.PodwozieId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Nadwozie).WithMany(d => d.Gokard).HasForeignKey(e => e.NadwozieId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Silnik).WithMany(d => d.Gokard).HasForeignKey(e => e.SilnikId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Tor).WithMany(d => d.Gokard).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.PersonalizowanyGokard).WithOne(d => d.Gokard).HasForeignKey<PersonalizowanyGokard>(e => e.GokardId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Przejazd).WithOne(d => d.Gokard).HasForeignKey(e => e.GokardId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Silnik>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Producent).HasMaxLength(50);
                entity.Property(e => e.Moc).IsRequired();
                entity.HasMany(e => e.Gokard).WithOne(d => d.Silnik).HasForeignKey(e => e.SilnikId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Podwozie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Producent).HasMaxLength(50);
                entity.HasMany(e => e.Gokard).WithOne(d => d.Podwozie).HasForeignKey(e => e.PodwozieId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Nadwozie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Producent).HasMaxLength(50);
                entity.HasMany(e => e.Gokard).WithOne(d => d.Nadwozie).HasForeignKey(e => e.NadwozieId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Przejazd>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Czas).IsRequired().HasColumnType("time");
                entity.Property(e => e.DataPrzejazdu).IsRequired().HasColumnType("datetime");
                entity.HasOne(e => e.Gokard).WithMany(d => d.Przejazd).HasForeignKey(e => e.GokardId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Tor).WithMany(d => d.Przejazd).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Kierowca).WithMany(d => d.Przejazd).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Tor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nazwa).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.Wlasciciel).WithMany(d => d.Tor).HasForeignKey(e => e.WlascicielId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Gokard).WithOne(d => d.Tor).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Przejazd).WithOne(d => d.Tor).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Pracownik).WithOne(d => d.Tor).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Stanowisko).HasMaxLength(50);
                entity.Property(e => e.Imie).IsRequired();
                entity.Property(e => e.Nazwisko).IsRequired();
                entity.HasOne(e => e.Tor).WithMany(d => d.Pracownik).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Kierowca>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.NumerKarty).HasMaxLength(50);
                entity.Property(e => e.Imie).IsRequired();
                entity.Property(e => e.Nazwisko).IsRequired();
                entity.HasMany(e => e.Przejazd).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.Sprzet).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.PersonalizowanyGokard).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(e => e.KierowcaSponsor).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId).HasConstraintName("Kierowca_KierowcaSponsor");
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasMany(e => e.KierowcaSponsor).WithOne(d => d.Sponsor).HasForeignKey(e => e.SponsorId).HasConstraintName("Sponsor_KierowcaSponsor");
            });

            modelBuilder.Entity<Sprzet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nazwa).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Kierowca).WithMany(d => d.Sprzet).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Wlasciciel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Imie).IsRequired();
                entity.Property(e => e.Nazwisko).IsRequired();
                entity.HasMany(e => e.Tor).WithOne(d => d.Wlasciciel).HasForeignKey(e => e.WlascicielId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PersonalizowanyGokard>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Kierowca).WithMany(d => d.PersonalizowanyGokard).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<KierowcaSponsor>(entity => entity.HasKey(e => new { e.KierowcaId, e.SponsorId}));

            SeedData(modelBuilder);
        }

        public void SeedData(ModelBuilder modelBuilder)
        {
            {

                //Adresy
                var Adresy = new List<Adres>();
                Adresy.Add(new Adres
                {
                    Id = 1,
                    Panstwo = "Włochy",
                    Miasto = "Monza",
                    Ulica = "Viale di Vedano, 5"
                }); 

                Adresy.Add(new Adres
                {
                    Id = 2,
                    Panstwo = "Belgia",
                    Miasto = "Stavelot",
                    Ulica = "Route du Circuit 55"
                }); 

                Adresy.Add(new Adres
                {
                    Id = 3,
                    Panstwo = "Holandia",
                    Miasto = "Zandvoort",
                    Ulica = "Burgemeester van Alphenstraat 108"
                }); 

                //Gokarty
                var Gokardy = new List<Gokard>();
                Gokardy.Add(new Gokard
                {
                    Id = 1,
                    Nazwa = "Junior",
                    Waga = 150,
                    Cena = 2000,
                    SilnikId = 2,
                    NadwozieId = 2,
                    PodwozieId = 2,
                    TorId = 3
                }); 

                Gokardy.Add(new Gokard
                {
                    Id = 2,
                    Nazwa = "Standard",
                    Waga = 160,
                    Cena = 3000,
                    SilnikId = 1,
                    NadwozieId = 1,
                    PodwozieId = 1,
                    TorId = 1
                }); 

                Gokardy.Add(new Gokard
                {
                    Id = 3,
                    Nazwa = "Standard+",
                    Waga = 180,
                    Cena = 4000,
                    SilnikId = 3,
                    NadwozieId = 3,
                    PodwozieId = 3,
                    TorId = 2
                }); 

                //Kierowcy
                var Kierowcy = new List<Kierowca>();
                Kierowcy.Add(new Kierowca
                {
                    Id = 1,
                    Imie = "Tomasz",
                    Nazwisko = "Kowalski",
                    Wiek = 21,
                    NumerKarty = "k1704"                    
                }); 

                Kierowcy.Add(new Kierowca
                {
                    Id = 2,
                    Imie = "Marcin",
                    Nazwisko = "Pędziwiatr",
                    Wiek = 16,
                    NumerKarty = "k898"
                }); 

                Kierowcy.Add(new Kierowca
                {
                    Id = 3,
                    Imie = "Jakub",
                    Nazwisko = "Mazur",
                    Wiek = 18,
                    NumerKarty = "k19"
                }); 

                //Kierowcy-Sponsorzy
                var KierowcySponsorzy = new List<KierowcaSponsor>();
                KierowcySponsorzy.Add(new KierowcaSponsor
                {
                    KierowcaId = 1,
                    SponsorId = 2
                }); 

                KierowcySponsorzy.Add(new KierowcaSponsor
                {
                    KierowcaId = 2,
                    SponsorId = 1
                }); 

                KierowcySponsorzy.Add(new KierowcaSponsor
                {
                    KierowcaId = 3,
                    SponsorId = 3
                }); 

                //Nadwozia
                var Nadwozia = new List<Nadwozie>();
                Nadwozia.Add(new Nadwozie
                {
                    Id = 1,
                    Producent = "Alfa Romeo",
                    Waga = 100,
                    Cena = 300
                }); 

                Nadwozia.Add(new Nadwozie
                {
                    Id = 2,
                    Producent = "Honda",
                    Waga = 200,
                    Cena = 400
                }); 

                Nadwozia.Add(new Nadwozie
                {
                    Id = 3,
                    Producent = "Chevrolet",
                    Waga = 300,
                    Cena = 400
                }); 

                //Podwozia
                var Podwozia = new List<Podwozie>();
                Podwozia.Add(new Podwozie
                {
                    Id = 1,
                    Producent = "Alfa Romeo",
                    Waga = 100,
                    Cena = 300
                }); 

                Podwozia.Add(new Podwozie
                {
                    Id = 2,
                    Producent = "Honda",
                    Waga = 400,
                    Cena = 700
                }); 

                Podwozia.Add(new Podwozie
                {
                    Id = 3,
                    Producent = "Chevrolet",
                    Waga = 300,
                    Cena = 100
                }); 

                //Pracownicy
                var Pracownicy = new List<Pracownik>();
                Pracownicy.Add(new Pracownik
                {
                    Id = 1,
                    Imie = "Paweł",
                    Nazwisko = "Wójcik",
                    Wiek = 25,
                    Stanowisko = "Recepcjonista",
                    Wynagrodzenie = 3300,
                    TorId = 1
                }); 

                Pracownicy.Add(new Pracownik
                {
                    Id = 2,
                    Imie = "Robert",
                    Nazwisko = "Walczak",
                    Wiek = 31,
                    Stanowisko = "Instruktor",
                    Wynagrodzenie = 4500,
                    TorId = 2
                }); 

                Pracownicy.Add(new Pracownik
                {
                    Id = 3,
                    Imie = "Krzysztof",
                    Nazwisko = "Błyskawica",
                    Wiek = 28,
                    Stanowisko = "Kierownik toru",
                    Wynagrodzenie = 5500,
                    TorId = 3
                }); 

                //Przejazdy
                var Przejazdy = new List<Przejazd>();
                Przejazdy.Add(new Przejazd
                {
                    Id = 1,
                    Czas = new TimeSpan(0, 0, 4, 25, 732),
                    DataPrzejazdu = new DateTime(2020, 06, 18, 11, 33, 47),
                    TorId = 1,
                    GokardId = 3,
                    KierowcaId = 1
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 2,
                    Czas = new TimeSpan(0, 0, 4, 27, 319),
                    DataPrzejazdu = new DateTime(2019, 12, 20, 17, 02, 13),
                    TorId = 1,
                    GokardId = 3,
                    KierowcaId = 1
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 3,
                    Czas = new TimeSpan(0, 0, 4, 25, 588),
                    DataPrzejazdu = new DateTime(2019, 10, 13, 16, 45, 38),
                    TorId = 1,
                    GokardId = 3,
                    KierowcaId = 1
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 4,
                    Czas = new TimeSpan(0, 0, 3, 59, 711),
                    DataPrzejazdu = new DateTime(2020, 07, 18, 14, 07, 16),
                    TorId = 3,
                    GokardId = 3,
                    KierowcaId = 2,
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 5,
                    Czas = new TimeSpan(0, 0, 3, 59, 646),
                    DataPrzejazdu = new DateTime(2020, 07, 18, 14, 12, 29),
                    TorId = 3,
                    GokardId = 3,
                    KierowcaId = 2,
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 6,
                    Czas = new TimeSpan(0, 0, 4, 02, 011),
                    DataPrzejazdu = new DateTime(2018, 10, 23, 20, 00, 36),
                    TorId = 3,
                    GokardId = 3,
                    KierowcaId = 2,
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 7,
                    Czas = new TimeSpan(0, 0, 05, 38, 412),
                    DataPrzejazdu = new DateTime(2019, 08, 30, 15, 56, 04),
                    TorId = 2,
                    GokardId = 3,
                    KierowcaId = 3,
                }); 


                Przejazdy.Add(new Przejazd
                {
                    Id = 8,
                    Czas = new TimeSpan(0, 0, 05, 41, 774),
                    DataPrzejazdu = new DateTime(2019, 09, 16, 09, 14, 36),
                    TorId = 2,
                    GokardId = 3,
                    KierowcaId = 3,
                }); 

                Przejazdy.Add(new Przejazd
                {
                    Id = 9,
                    Czas = new TimeSpan(0, 0, 05, 37, 292),
                    DataPrzejazdu = new DateTime(2020, 08, 17, 12, 37, 40),
                    TorId = 2,
                    GokardId = 3,
                    KierowcaId = 3,
                }); 

                //Silniki
                var Silniki = new List<Silnik>();
                Silniki.Add(new Silnik
                {
                    Id = 1,
                    Moc = 20,
                    Pojemnosc = 600,
                    Producent = "Mercedes",
                    Waga = 700,
                    Cena = 300
                }); 

                Silniki.Add(new Silnik
                {
                    Id = 2,
                    Moc = 15,
                    Pojemnosc = 350,
                    Producent = "Audi",
                    Waga = 600,
                    Cena = 800
                }); 

                Silniki.Add(new Silnik
                {
                    Id = 3,
                    Moc = 25,
                    Pojemnosc = 800,
                    Producent = "Ferrari",
                    Waga = 500,
                    Cena = 900
                }); 

                //Sponsorzy
                var Sponsorzy = new List<Sponsor>();
                Sponsorzy.Add(new Sponsor
                {
                    Id = 1,
                    Nazwa = "ORLEN"
                }); 

                Sponsorzy.Add(new Sponsor
                {
                    Id = 2,
                    Nazwa = "STS"
                }); 

                Sponsorzy.Add(new Sponsor
                {
                    Id = 3,
                    Nazwa = "PEKAO"
                }); 

                //Sprzety
                var Sprzety = new List<Sprzet>();
                Sprzety.Add(new Sprzet
                {
                    Id = 1,
                    Nazwa = "Kask czerwony mały",
                    Koszt = 25.0,
                    KierowcaId = 1
                }); 

                Sprzety.Add(new Sprzet
                {
                    Id = 2,
                    Nazwa = "Rękawice czarne normalne",
                    Koszt = 15,
                    KierowcaId = null
                }); 

                Sprzety.Add(new Sprzet
                {
                    Id = 3,
                    Nazwa = "Kominiarka normalna",
                    Koszt = 10,
                    KierowcaId = 3
                }); 

                //Wlascicele
                var Wlasciciele = new List<Wlasciciel>();
                Wlasciciele.Add(new Wlasciciel
                {
                    Id = 1,
                    Imie = "Wiktor",
                    Nazwisko = "Charitonin"
                }); 

                Wlasciciele.Add(new Wlasciciel
                {
                    Id = 2,
                    Imie = "Gerard",
                    Nazwisko = "Lopez"
                }); 

                //Tory
                var Tory = new List<Tor>();
                Tory.Add(new Tor
                {
                    Id = 1,
                    Nazwa = "Autodromo Nazionale di Monza",
                    Dlugosc = 5.793,
                    StawkaGodzinowa = 400,
                    AdresId = 1,
                    WlascicielId = 2
                }); 

                Tory.Add(new Tor
                {
                    Id = 2,
                    Nazwa = "Circuit de Spa-Francorchamps",
                    Dlugosc = 7.004,
                    StawkaGodzinowa = 450,
                    AdresId = 2,
                    WlascicielId = 1
                }); 

                Tory.Add(new Tor
                {
                    Id = 3,
                    Nazwa = "Circuit Zandvoort",
                    Dlugosc = 4.252,
                    StawkaGodzinowa = 350,
                    AdresId = 3,
                    WlascicielId = 1
                });             

                //Dodanie
                modelBuilder.Entity<Adres>().HasData(Adresy);
                modelBuilder.Entity<Gokard>().HasData(Gokardy);
                modelBuilder.Entity<Kierowca>().HasData(Kierowcy);
                modelBuilder.Entity<KierowcaSponsor>().HasData(KierowcySponsorzy);
                modelBuilder.Entity<Nadwozie>().HasData(Nadwozia);
                modelBuilder.Entity<Podwozie>().HasData(Podwozia);
                modelBuilder.Entity<Pracownik>().HasData(Pracownicy);
                modelBuilder.Entity<Przejazd>().HasData(Przejazdy);
                modelBuilder.Entity<Silnik>().HasData(Silniki);
                modelBuilder.Entity<Sponsor>().HasData(Sponsorzy);
                modelBuilder.Entity<Sprzet>().HasData(Sprzety);
                modelBuilder.Entity<Wlasciciel>().HasData(Wlasciciele);
                modelBuilder.Entity<Tor>().HasData(Tory);
            }
        }
    }
}
