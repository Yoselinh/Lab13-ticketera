using Lab13_YoselinCcapera.Application.Services;
using Lab13_YoselinCcapera.Domain.Dtos;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Reports.Query;

public class GetClientSalesReportQuery : IRequest<List<ClientSalesReportDto>>
{
}

internal sealed class GetClientSalesReportQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetClientSalesReportQuery, List<ClientSalesReportDto>>
{
    public async Task<List<ClientSalesReportDto>> Handle(GetClientSalesReportQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Reports.GetClientSalesAsync();
    }
}