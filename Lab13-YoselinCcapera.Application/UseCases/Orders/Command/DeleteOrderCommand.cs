using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Orders.Command;

public record DeleteOrderCommand : IRequest<Unit>
{
    public int OrderId { get; set; }
}

internal sealed class DeleteOrderCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<DeleteOrderCommand, Unit>
{
    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Order>();

        var order = await repository.GetByIdAsync(request.OrderId)
                    ?? throw new KeyNotFoundException("Order not found");

        repository.Delete(order);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

