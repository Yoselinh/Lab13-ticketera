using ClosedXML.Excel;
using Lab13_YoselinCcapera.Application.Services;
using Lab13_YoselinCcapera.Domain.Dtos;

namespace Lab13_YoselinCcapera.IInfrastructure.Adapters.Services;


public class ExcelReportService : IExcelReportService
{
    public byte[] GenerateClientSalesReport(List<ClientSalesReportDto> data)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Ventas por cliente");

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Cliente";
        worksheet.Cell(1, 3).Value = "Email";
        worksheet.Cell(1, 4).Value = "Total de pedidos";
        worksheet.Cell(1, 5).Value = "Total gastado";
        ApplyHeaderStyle(worksheet, 5);

        var row = 2;
        foreach (var item in data)
        {
            worksheet.Cell(row, 1).Value = item.ClientId;
            worksheet.Cell(row, 2).Value = item.ClientName;
            worksheet.Cell(row, 3).Value = item.Email;
            worksheet.Cell(row, 4).Value = item.TotalOrders;
            worksheet.Cell(row, 5).Value = item.TotalSpent;
            row++;
        }

        worksheet.Column(5).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Columns().AdjustToContents();

        return ToBytes(workbook);
    }

    public byte[] GenerateProductSalesReport(List<ProductSalesReportDto> data)
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Ventas por producto");

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Producto";
        worksheet.Cell(1, 3).Value = "Cantidad vendida";
        worksheet.Cell(1, 4).Value = "Monto total";
        ApplyHeaderStyle(worksheet, 4);

        var row = 2;
        foreach (var item in data)
        {
            worksheet.Cell(row, 1).Value = item.ProductId;
            worksheet.Cell(row, 2).Value = item.ProductName;
            worksheet.Cell(row, 3).Value = item.TotalQuantity;
            worksheet.Cell(row, 4).Value = item.TotalAmount;
            row++;
        }

        worksheet.Column(4).Style.NumberFormat.Format = "#,##0.00";
        worksheet.Columns().AdjustToContents();

        return ToBytes(workbook);
    }

    private static void ApplyHeaderStyle(IXLWorksheet worksheet, int columns)
    {
        var header = worksheet.Range(1, 1, 1, columns);
        header.Style.Font.Bold = true;
        header.Style.Fill.BackgroundColor = XLColor.Cyan;
        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
    }

    private static byte[] ToBytes(XLWorkbook workbook)
    {
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }
}