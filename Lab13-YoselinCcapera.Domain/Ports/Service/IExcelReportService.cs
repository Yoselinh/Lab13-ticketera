namespace Lab13_YoselinCcapera.Domain.Ports.Service;

public interface IExcelReportService
{
    Task<byte[]> GenerateClientSalesReportAsync();
    Task<byte[]> GenerateProductSalesReportAsync();
}