namespace Lab13_YoselinCcapera.Domain.Dtos;

public class ProductSalesReportDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int TotalQuantity { get; set; }
    public decimal TotalAmount { get; set; }
}