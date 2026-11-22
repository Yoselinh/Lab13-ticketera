using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Products.Command;


public record AddProductCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

internal sealed class AddProductCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<AddProductCommand, Unit>
{
    public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        await unitOfWork.Repository<Product>().AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}