using Lab13_YoselinCcapera.Application.Services;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Reports.Query;

public class GetClientSalesReportQuery : IRequest<byte[]>
{
}

internal sealed class GetClientSalesReportQueryHandler(IUnityOfWork unitOfWork, IExcelReportService excelReportService) : IRequestHandler<GetClientSalesReportQuery, byte[]>
{
    public async Task<byte[]> Handle(GetClientSalesReportQuery request, CancellationToken cancellationToken)
    {
        var data = await unitOfWork.Reports.GetClientSalesAsync();

        return excelReportService.GenerateClientSalesReport(data);
    }
}