using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Command;

public record DeleteOrderDetailCommand : IRequest<Unit>
{
    public int OrderDetailId { get; set; }
}

internal sealed class DeleteOrderDetailCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<DeleteOrderDetailCommand, Unit>
{
    public async Task<Unit> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Orderdetail>();

        var orderDetail = await repository.GetByIdAsync(request.OrderDetailId)
                          ?? throw new KeyNotFoundException("OrderDetail not found");

        repository.Delete(orderDetail);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

