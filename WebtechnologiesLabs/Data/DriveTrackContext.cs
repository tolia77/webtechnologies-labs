using Microsoft.EntityFrameworkCore;
using WebtechnologiesLabs.Models;

namespace WebtechnologiesLabs.Data;

public class DriveTrackContext : DbContext
{
    public DriveTrackContext(DbContextOptions<DriveTrackContext> options)
        : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // one vehicle - one driver
        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Vehicle)
            .WithOne(v => v.Driver)
            .HasForeignKey<Driver>(d => d.VehicleId)
            .OnDelete(DeleteBehavior.SetNull);

        // one delivery - one review
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Delivery)
            .WithOne(d => d.Review)
            .HasForeignKey<Review>(r => r.DeliveryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Delivery>()
            .HasOne(d => d.Driver)
            .WithMany(d => d.Deliveries)
            .HasForeignKey(d => d.DriverId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Delivery>()
            .HasOne(d => d.Client)
            .WithMany(c => c.Deliveries)
            .HasForeignKey(d => d.ClientId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Vehicle>()
            .HasIndex(v => v.LicensePlate)
            .IsUnique();
    }
}
