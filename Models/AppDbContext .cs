using Microsoft.EntityFrameworkCore;
using TaşımacılıkOtomasyonu.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .Property(v => v.Status)
            .HasMaxLength(50);

        modelBuilder.Entity<Driver>()
            .Property(d => d.PhoneNumber)
            .HasMaxLength(15);

        modelBuilder.Entity<Route>()
            .Property(r => r.Distance)
            .HasColumnType("float");

        modelBuilder.Entity<Shipment>()
            .Property(s => s.ShipmentDate)
            .HasColumnType("datetime");
    }
}
