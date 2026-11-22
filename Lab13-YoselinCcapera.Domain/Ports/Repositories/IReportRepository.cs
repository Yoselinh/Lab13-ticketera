using Lab13_YoselinCcapera.Domain.Dtos;

namespace Lab13_YoselinCcapera.Domain.Ports.Repositories;

public interface IReportRepository
{
    Task<List<ClientSalesReportDto>> GetClientSalesAsync();
    Task<List<ProductSalesReportDto>> GetProductSalesAsync();
}