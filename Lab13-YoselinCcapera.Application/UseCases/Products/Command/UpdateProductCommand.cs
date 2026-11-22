using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Products.Command;

public record UpdateProductCommand : IRequest<Unit>
{
    public int ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

internal sealed class UpdateProductCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Product>();

        var product = await repository.GetByIdAsync(request.ProductId)
                      ?? throw new KeyNotFoundException("Product not found");

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;

        repository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}