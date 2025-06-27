using Microsoft.EntityFrameworkCore;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyDetails> Details { get; set; }
    public DbSet<PropertyImage> Images { get; set; }
    public DbSet<PropertyVideo> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(u => u.Email).IsUnique();
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(p => p.Id);
            entity.HasOne(p => p.Details)
              .WithOne(d => d.Property)
              .HasForeignKey<PropertyDetails>(d => d.PropertyId);

            entity.HasMany(p => p.Images)
              .WithOne(i => i.Property)
              .HasForeignKey(i => i.PropertyId);

            entity.HasMany(p => p.Videos)
              .WithOne(v => v.Property)
              .HasForeignKey(v => v.PropertyId);
        });

        modelBuilder.Entity<PropertyDetails>(entity =>
        {
            entity.HasKey(d => d.Id);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost;Database=RealStateDB;Username=postgres;Password=12345");
    }
}
