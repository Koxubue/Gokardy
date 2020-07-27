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

           // modelBuilder.Entity<PrescriptionMedicament>()
           //.HasKey(e => new { e.IdMedicament, e.IdPrescription });

            //SeedData(modelBuilder);
        }
    }
}
