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
        public DbSet<Uzytkownik> Uzytkownik { get; set; }

        public GokardyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasKey(e => e.Id );
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
                entity.HasMany(e => e.Przejazd).WithOne(d => d.Gokard).HasForeignKey(e => e.GokardId);
            });

            modelBuilder.Entity<Silnik>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Producent).HasMaxLength(50);
                entity.Property(e => e.Moc).IsRequired();
                entity.HasMany(e => e.Gokard).WithOne(d => d.Silnik).HasForeignKey(e => e.SilnikId);
            });

            modelBuilder.Entity<Podwozie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Producent).HasMaxLength(50);
                entity.HasMany(e => e.Gokard).WithOne(d => d.Podwozie).HasForeignKey(e => e.PodwozieId);
            });

            modelBuilder.Entity<Nadwozie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Producent).HasMaxLength(50);
                entity.HasMany(e => e.Gokard).WithOne(d => d.Nadwozie).HasForeignKey(e => e.NadwozieId);
            });

            modelBuilder.Entity<Przejazd>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Czas).IsRequired().HasColumnType("date");
                entity.HasOne(e => e.Gokard).WithMany(d => d.Przejazd).HasForeignKey(e => e.GokardId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Tor).WithMany(d => d.Przejazd).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Kierowca).WithMany(d => d.Przejazd).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Tor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nazwa).IsRequired().HasMaxLength(100);
                entity.HasMany(e => e.Gokard).WithOne(d => d.Tor).HasForeignKey(e => e.TorId);
                entity.HasMany(e => e.Przejazd).WithOne(d => d.Tor).HasForeignKey(e => e.TorId);
                entity.HasMany(e => e.Pracownik).WithOne(d => d.Tor).HasForeignKey(e => e.TorId);
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Stanowisko).HasMaxLength(50);
                entity.Property(e => e.Imie).IsRequired();
                entity.Property(e => e.Nazwisko).IsRequired();
                entity.HasOne(e => e.Tor).WithMany(d => d.Pracownik).HasForeignKey(e => e.TorId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Uzytkownik>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Login).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Haslo).IsRequired().HasMaxLength(30);
                entity.HasOne(e => e.Pracownik).WithOne(d => d.Uzytkownik).HasForeignKey<Pracownik>(e => e.UzytkownikId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(e => e.Kierowca).WithOne(d => d.Uzytkownik).HasForeignKey<Kierowca>(e => e.UzytkownikId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Kierowca>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NumerKarty).HasMaxLength(50);
                entity.Property(e => e.Imie).IsRequired();
                entity.Property(e => e.Nazwisko).IsRequired();
                entity.HasMany(e => e.Przejazd).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId);
                entity.HasMany(e => e.Sprzet).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId);
                entity.HasMany(e => e.KierowcaSponsor).WithOne(d => d.Kierowca).HasForeignKey(e => e.KierowcaId).HasConstraintName("Kierowca_KierowcaSponsor");
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.KierowcaSponsor).WithOne(d => d.Sponsor).HasForeignKey(e => e.SponsorId).HasConstraintName("Sponsor_KierowcaSponsor");
            });

            modelBuilder.Entity<Sprzet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nazwa).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Kierowca).WithMany(d => d.Sprzet).HasForeignKey(e => e.KierowcaId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<KierowcaSponsor>(entity => entity.HasKey(e => new { e.KierowcaId, e.SponsorId}));

            SeedData(modelBuilder);
        }

        public void SeedData(ModelBuilder modelBuilder)
        {

        }
    }
}
