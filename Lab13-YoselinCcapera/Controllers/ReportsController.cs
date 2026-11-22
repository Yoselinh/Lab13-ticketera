using Lab13_YoselinCcapera.Domain.Ports.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_YoselinCcapera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController(IExcelReportService excelReportService) : ControllerBase
{
    private const string ExcelContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

    
    [HttpGet("client-sales")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, ExcelContentType)]
    public async Task<IActionResult> GetClientSalesReport()
    {
        var file = await excelReportService.GenerateClientSalesReportAsync();
        return File(file, ExcelContentType, "ReporteVentasPorCliente.xlsx");
    }

    [HttpGet("product-sales")]
    [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK, ExcelContentType)]
    public async Task<IActionResult> GetProductSalesReport()
    {
        var file = await excelReportService.GenerateProductSalesReportAsync();
        return File(file, ExcelContentType, "ReporteVentasPorProducto.xlsx");
    }
}