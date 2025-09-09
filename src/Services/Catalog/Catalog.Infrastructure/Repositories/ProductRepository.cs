using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository // Implement the interface
{
    private readonly CatalogContext _context;

    // We ask for a CatalogContext via constructor injection
    public ProductRepository(CatalogContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Product?> GetProductByIdAsync(Guid id) 
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            // Handle concurrency conflict if needed
            if (!ProductExists(product.Id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }
    }

    private bool ProductExists(Guid id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}