using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<Invoice> GetByIdAsync(int invoiceId);
    }
}
