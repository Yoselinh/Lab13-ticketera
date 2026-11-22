using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Orders.Query;

public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
{
}

internal sealed class GetAllOrdersQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetAllOrdersQuery, IEnumerable<Order>>
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Order>().GetAllAsync();
    }
}

