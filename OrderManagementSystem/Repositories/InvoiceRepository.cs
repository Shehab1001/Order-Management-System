using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories.Interfaces;

namespace OrderManagementSystem.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly OrderManagementDbContext _context;

        public InvoiceRepository(OrderManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetByIdAsync(int invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }
    }
}
