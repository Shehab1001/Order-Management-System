using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task UpdateProductAsync(int productId, Product product);
    }
}
