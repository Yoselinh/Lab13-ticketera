using Lab13_YoselinCcapera.Domain.Dtos;

namespace Lab13_YoselinCcapera.Application.Services;


public interface IExcelReportService
{
    byte[] GenerateClientSalesReport(List<ClientSalesReportDto> data);
    byte[] GenerateProductSalesReport(List<ProductSalesReportDto> data);
}