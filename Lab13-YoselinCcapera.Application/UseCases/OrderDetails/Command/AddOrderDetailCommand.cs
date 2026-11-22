using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Command;

public record AddOrderDetailCommand : IRequest<Unit>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

internal sealed class AddOrderDetailCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<AddOrderDetailCommand, Unit>
{
    public async Task<Unit> Handle(AddOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = new Orderdetail
        {
            Orderid = request.OrderId,
            Productid = request.ProductId,
            Quantity = request.Quantity
        };

        await unitOfWork.Repository<Orderdetail>().AddAsync(orderDetail);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}

