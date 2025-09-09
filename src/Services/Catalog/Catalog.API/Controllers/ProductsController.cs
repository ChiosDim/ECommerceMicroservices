using AutoMapper;
using Catalog.API.Dtos;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")] // This means the route will be /api/products
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    // Dependency Injection: The framework will provide us with a ProductRepository
    public ProductsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts()
    {
        var products = await _productRepository.GetProductsAsync();
        var response = _mapper.Map<IEnumerable<ProductResponse>>(products);
        return Ok(response);
    }

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse>> GetProduct(Guid id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null) return NotFound();

        var response = _mapper.Map<ProductResponse>(product);
        return Ok(response);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<ProductResponse>> CreateProduct(CreateProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        product.Id = Guid.NewGuid();
        product.CreatedDate = DateTimeOffset.UtcNow;

        var createdProduct = await _productRepository.CreateProductAsync(product);
        var response = _mapper.Map<ProductResponse>(createdProduct);

        return CreatedAtAction(nameof(GetProduct), new { id = response.Id }, response);
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, CreateProductRequest request)
    {
        var existingProduct = await _productRepository.GetProductByIdAsync(id);
        if (existingProduct == null) return NotFound();

        _mapper.Map(request, existingProduct);
        existingProduct.UpdatedDate = DateTimeOffset.UtcNow;

        var updateResult = await _productRepository.UpdateProductAsync(existingProduct);
        if (!updateResult) return NotFound();

        return NoContent();
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var deleteResult = await _productRepository.DeleteProductAsync(id);
        if (!deleteResult) return NotFound();
        return NoContent();
    }
}