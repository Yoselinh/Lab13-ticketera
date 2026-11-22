using Lab13_YoselinCcapera.Application.Services;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Reports.Query;


public class GetProductSalesReportQuery : IRequest<byte[]>
{
}

internal sealed class GetProductSalesReportQueryHandler(IUnityOfWork unitOfWork, IExcelReportService excelReportService) : IRequestHandler<GetProductSalesReportQuery, byte[]>
{
    public async Task<byte[]> Handle(GetProductSalesReportQuery request, CancellationToken cancellationToken)
    {
        var data = await unitOfWork.Reports.GetProductSalesAsync();

        return excelReportService.GenerateProductSalesReport(data);
    }
}