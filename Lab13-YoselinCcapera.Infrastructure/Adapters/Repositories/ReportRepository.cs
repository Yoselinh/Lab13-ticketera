using Lab13_YoselinCcapera.Domain.Dtos;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using Lab13_YoselinCcapera.IInfrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Lab13_YoselinCcapera.IInfrastructure.Adapters.Repositories;

public class ReportRepository(ApplicationDbContext context) : IReportRepository
{
    public async Task<List<ClientSalesReportDto>> GetClientSalesAsync()
    {
        var data = await context.Clients
            .Select(c => new ClientSalesReportDto
            {
                ClientId = c.Clientid,
                ClientName = c.Name,
                Email = c.Email,
                TotalOrders = c.Orders.Count(),
                TotalSpent = c.Orders
                    .SelectMany(o => o.Orderdetails)
                    .Sum(d => (decimal?)(d.Quantity * d.Product.Price)) ?? 0
            })
            .ToListAsync();

        return data.OrderByDescending(x => x.TotalSpent).ToList();
    }

    public async Task<List<ProductSalesReportDto>> GetProductSalesAsync()
    {
        var data = await context.Products
            .Select(p => new ProductSalesReportDto
            {
                ProductId = p.Productid,
                ProductName = p.Name,
                TotalQuantity = p.Orderdetails.Sum(d => (int?)d.Quantity) ?? 0,
                TotalAmount = p.Orderdetails.Sum(d => (decimal?)(d.Quantity * p.Price)) ?? 0
            })
            .ToListAsync();

        return data.OrderByDescending(x => x.TotalAmount).ToList();
    }
}