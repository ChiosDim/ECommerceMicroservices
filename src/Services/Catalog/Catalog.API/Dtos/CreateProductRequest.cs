using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Dtos;

public class CreateProductRequest
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public required string Name { get; set; }

    [Required]
    [StringLength(500)]
    public required string Description { get; set; }

    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    [Range(0, 1000)]
    public int AvailableStock { get; set; }
}