namespace Lab13_YoselinCcapera.Domain.Dtos;

public class ClientSalesReportDto
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int TotalOrders { get; set; }
    public decimal TotalSpent { get; set; }
}