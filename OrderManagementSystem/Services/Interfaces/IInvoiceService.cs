using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int invoiceId);
    }
}
