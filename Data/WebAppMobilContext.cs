using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMobil.Models;

namespace WebAppMobil.Data
{
    public class WebAppMobilContext : DbContext
    {
        public WebAppMobilContext (DbContextOptions<WebAppMobilContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppMobil.Models.Driver> Driver { get; set; } = default!;
        public DbSet<WebAppMobil.Models.Car> Car { get; set; } = default!;
        public DbSet<WebAppMobil.Models.Logbook> Logbook { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Driver)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DriverID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Logbook>()
                .HasOne(l => l.Car)
                .WithMany()
                .HasForeignKey(l => l.CarID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Logbook>()
                .HasOne(l => l.Driver)
                .WithMany()
                .HasForeignKey(l => l.DriverID)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
