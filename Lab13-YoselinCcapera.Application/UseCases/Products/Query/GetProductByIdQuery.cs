using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Products.Query;

public class GetProductByIdQuery : IRequest<Product>
{
    public int ProductId { get; set; }
}

internal sealed class GetProductByIdQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetProductByIdQuery, Product>
{
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Product>().GetByIdAsync(request.ProductId)
               ?? throw new KeyNotFoundException("Product not found");
    }
}

