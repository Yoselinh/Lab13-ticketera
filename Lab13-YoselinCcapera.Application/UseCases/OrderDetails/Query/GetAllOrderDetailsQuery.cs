using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Query;

public class GetAllOrderDetailsQuery : IRequest<IEnumerable<Orderdetail>>
{
}

internal sealed class GetAllOrderDetailsQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetAllOrderDetailsQuery, IEnumerable<Orderdetail>>
{
    public async Task<IEnumerable<Orderdetail>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Orderdetail>().GetAllAsync();
    }
}

