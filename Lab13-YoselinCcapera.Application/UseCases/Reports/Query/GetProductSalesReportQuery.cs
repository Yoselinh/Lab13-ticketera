using Lab13_YoselinCcapera.Application.Services;
using Lab13_YoselinCcapera.Domain.Dtos;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Reports.Query;


public class GetProductSalesReportQuery : IRequest<List<ProductSalesReportDto>>
{
}

internal sealed class GetProductSalesReportQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetProductSalesReportQuery, List<ProductSalesReportDto>>
{
    public async Task<List<ProductSalesReportDto>> Handle(GetProductSalesReportQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Reports.GetProductSalesAsync();
    }
}