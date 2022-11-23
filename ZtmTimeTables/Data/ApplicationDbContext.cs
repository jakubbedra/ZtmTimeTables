using Microsoft.EntityFrameworkCore;
using ZtmTimeTables.Entity;

namespace ZtmTimeTables.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<UserStop>? UserStops { get; set; }
    
    public ApplicationDbContext() : base()
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.BookmarkedStops)
            .WithOne(b => b.User);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=ZtmTables.db");
    }
}