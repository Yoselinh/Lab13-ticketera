using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Command;

public record UpdateOrderDetailCommand : IRequest<Unit>
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

internal sealed class UpdateOrderDetailCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<UpdateOrderDetailCommand, Unit>
{
    public async Task<Unit> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Orderdetail>();

        var orderDetail = await repository.GetByIdAsync(request.OrderDetailId)
                          ?? throw new KeyNotFoundException("OrderDetail not found");

        orderDetail.Orderid = request.OrderId;
        orderDetail.Productid = request.ProductId;
        orderDetail.Quantity = request.Quantity;

        repository.Update(orderDetail);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

