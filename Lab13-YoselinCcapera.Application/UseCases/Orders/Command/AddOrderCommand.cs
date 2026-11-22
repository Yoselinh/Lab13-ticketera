using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Orders.Command;

public record AddOrderCommand : IRequest<Unit>
{
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
}

internal sealed class AddOrderCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<AddOrderCommand, Unit>
{
    public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Clientid = request.ClientId,
            Orderdate = request.OrderDate
        };

        await unitOfWork.Repository<Order>().AddAsync(order);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

