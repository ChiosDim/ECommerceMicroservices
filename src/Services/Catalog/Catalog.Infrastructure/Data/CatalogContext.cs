using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Data;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!; // The DbSet represents the Products table

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}