using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Orders.Command;

public record UpdateOrderCommand : IRequest<Unit>
{
    public int OrderId { get; set; }
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; }
}

internal sealed class UpdateOrderCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<UpdateOrderCommand, Unit>
{
    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Order>();

        var order = await repository.GetByIdAsync(request.OrderId)
                    ?? throw new KeyNotFoundException("Order not found");

        order.Clientid = request.ClientId;
        order.Orderdate = request.OrderDate;

        repository.Update(order);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

