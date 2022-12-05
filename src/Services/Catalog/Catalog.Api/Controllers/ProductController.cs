using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IConfiguration _configuration;
    private ILogger<ProductController> _logger;

    public ProductController(IProductRepository productRepository, IConfiguration configuration,
        ILogger<ProductController> logger)
    {
        _configuration = configuration;
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        return Ok(products);
    }

    [HttpGet("[action]/{id}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProduct(long id)
    {
        var products = await _productRepository.GetProduct(id);
        if (products == null)
        {
            _logger.LogError("cannot fide product by id:" + id);
            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("[action]/{name}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
    {
        var products = await _productRepository.GetProductsByName(name);
        if (products == null || products.Count() == 0)
        {
            _logger.LogError("cannot fide product by name : " + name);
            return NotFound();
        }

        return Ok(products);
    }

    [HttpGet("[action]/{category}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
    {
        var products = await _productRepository.GetProductsByCategory(category);
        if (products == null || products.Count() == 0)
        {
            _logger.LogError("cannot fide product by category : " + category);
            return NotFound();
        }

        return Ok(products);
    }
    
    [HttpPost("[action]")]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _productRepository.CreateProduct(product);
        return Ok(product);
    }
    [HttpPut("[action]")]
    public async Task<ActionResult<Product>> UpdateProduct(Product product)
    {
        return Ok(await _productRepository.UpdateProduct(product));
    }
    [HttpPut("[action]")]
    public async Task<ActionResult<Product>> DeleteProduct(long id)
    {
        return Ok(await _productRepository.DeleteProduct(id));
    }
}