using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Orders.Query;

public class GetOrderByIdQuery : IRequest<Order>
{
    public int OrderId { get; set; }
}

internal sealed class GetOrderByIdQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetOrderByIdQuery, Order>
{
    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Order>().GetByIdAsync(request.OrderId)
               ?? throw new KeyNotFoundException("Order not found");
    }
}

