using Microsoft.EntityFrameworkCore;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Data;

public class ApplicationDbContext : DbContext
{
//    public DbSet<Product> Products { get; set; }
//    public DbSet<Customer> Customers { get; set; }
//    public DbSet<Order> Orders { get; set; }
    
//    public DbSet<OrderProduct> OrderProducts { get; set; }

    

    public DbSet<ZtmStop> ZtmStops { get; set; }
    public DbSet<ZtmVehicle> ZtmVehicles { get; set; }
    public DbSet<ZtmVehicleArrival> ZtmVehicleArrivals { get; set; }

    public ApplicationDbContext() : base()
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ZtmVehicle>()
            .HasMany(v => v.Arrivals)
            .WithOne(a => a.Vehicle);
        modelBuilder.Entity<ZtmStop>()
            .HasMany(s => s.VehicleArrivals)
            .WithOne(a => a.ZtmStop);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=ZtmTables.db");
    }
}