// ProductResponse.cs
namespace Catalog.API.Dtos;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int AvailableStock { get; set; }
    public DateTimeOffset CreatedDate { get; set; } 
    public DateTimeOffset? UpdatedDate { get; set; }
}