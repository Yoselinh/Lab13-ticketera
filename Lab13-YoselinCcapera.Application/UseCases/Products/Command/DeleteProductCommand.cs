using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Products.Command;

public record DeleteProductCommand : IRequest<Unit>
{
    public int ProductId { get; set; }
}

internal sealed class DeleteProductCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Product>();

        var product = await repository.GetByIdAsync(request.ProductId)
                      ?? throw new KeyNotFoundException("Product not found");

        repository.Delete(product);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}