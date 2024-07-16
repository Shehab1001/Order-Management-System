using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int productId);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(int productId, Product product);
    }
}
