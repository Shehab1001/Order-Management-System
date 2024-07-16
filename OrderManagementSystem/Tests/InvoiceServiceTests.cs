using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Repositories;
using OrderManagementSystem.Services;
using Xunit;

public class InvoiceServiceTests
{
    private readonly InvoiceService _invoiceService;
    private readonly OrderManagementDbContext _context;

    public InvoiceServiceTests()
    {
        var options = new DbContextOptionsBuilder<OrderManagementDbContext>()
            .UseInMemoryDatabase(databaseName: "OrderManagementDbTest")
            .Options;
        _context = new OrderManagementDbContext(options);
        var invoiceRepository = new InvoiceRepository(_context);
        _invoiceService = new InvoiceService(invoiceRepository);
    }

    [Fact]
    public async Task GetInvoiceById_ShouldReturnInvoice()
    {
        var invoice = new Invoice
        {
            OrderId = 1,
            InvoiceDate = DateTime.UtcNow,
            TotalAmount = 100
        };
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        var fetchedInvoice = await _invoiceService.GetInvoiceByIdAsync(invoice.InvoiceId);

        Assert.NotNull(fetchedInvoice);
        Assert.Equal(invoice.TotalAmount, fetchedInvoice.TotalAmount);
    }

    [Fact]
    public async Task GetInvoices_ShouldReturnInvoices()
    {
        _context.Invoices.Add(new Invoice { OrderId = 1, InvoiceDate = DateTime.UtcNow, TotalAmount = 100 });
        await _context.SaveChangesAsync();

        var invoices = await _invoiceService.GetInvoicesAsync();

        Assert.NotNull(invoices);
        Assert.Single(invoices);
    }
}
