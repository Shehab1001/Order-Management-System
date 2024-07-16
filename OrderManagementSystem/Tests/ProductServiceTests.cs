using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;
using Xunit;

public class ProductServiceTests
{
    private readonly ProductService _productService;
    private readonly OrderManagementDbContext _context;

    public ProductServiceTests()
    {
        var options = new DbContextOptionsBuilder<OrderManagementDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderManagementDbTest")
            .Options;
        _context = new OrderManagementDbContext(options);
        var productRepository = new ProductRepository(_context);
        _productService = new ProductService(productRepository);
    }

    [Fact]
    public async Task AddProduct_ShouldAddProduct()
    {
        var product = new Product
        {
            Name = "Test Product",
            Price = 50,
            Stock = 10
        };

        var createdProduct = await _productService.AddProductAsync(product);

        Assert.NotNull(createdProduct);
        Assert.Equal(product.Name, createdProduct.Name);
    }

    [Fact]
    public async Task GetProducts_ShouldReturnProducts()
    {
        _context.Products.Add(new Product { Name = "Test Product", Price = 50, Stock = 10 });
        await _context.SaveChangesAsync();

        var products = await _productService.GetProductsAsync();

        Assert.NotNull(products);
        Assert.Single(products);
    }
}
