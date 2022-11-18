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
        /*
        modelBuilder.Entity<Customer>()
            .HasDiscriminator<char>("customerType")
            .HasValue<Customer>('N')
            .HasValue<WebCustomer>('W');
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer);
        
        modelBuilder.Entity<Order>()
            .HasDiscriminator<char>("orderType")
            .HasValue<Order>('N')
            .HasValue<WebOrder>('W');
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Products)
            .WithOne(op => op.Order);
        
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Orders)
            .WithOne(op => op.Product);
      
        modelBuilder.Entity<OrderProduct>()
            .HasOne(p => p.Product)
            .WithMany(p => p.Orders);
        modelBuilder.Entity<OrderProduct>()
            .HasOne(p => p.Order)
            .WithMany(o => o.Products);
            */
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=ZtmTables.db");
    }
}