using Lab13_YoselinCcapera.Application.UseCases.Clients.Query;
using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Products.Query;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
}

internal sealed class GetAllProductsQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Product>().GetAllAsync();
    }
}