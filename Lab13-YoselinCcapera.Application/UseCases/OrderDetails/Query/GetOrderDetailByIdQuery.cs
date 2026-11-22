using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Query;

public class GetOrderDetailByIdQuery : IRequest<Orderdetail>
{
    public int OrderDetailId { get; set; }
}

internal sealed class GetOrderDetailByIdQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetOrderDetailByIdQuery, Orderdetail>
{
    public async Task<Orderdetail> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Orderdetail>().GetByIdAsync(request.OrderDetailId)
               ?? throw new KeyNotFoundException("OrderDetail not found");
    }
}

