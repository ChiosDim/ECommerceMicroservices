using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Catalog.Domain.Features.Auth; 

namespace Catalog.Infrastructure.Data;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!; // The DbSet represents the Products table
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<User>(entity =>
        {
             entity.HasKey(u => u.Id);
             entity.HasIndex(u => u.Email).IsUnique();
        });
    }
}