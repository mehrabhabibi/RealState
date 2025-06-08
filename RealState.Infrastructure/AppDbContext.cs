using Microsoft.EntityFrameworkCore;

namespace RealState.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }
    // public DbSet<Property> Properties { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost;Database=RealStateDB;Username=postgres;Password=12345");
    }
}
