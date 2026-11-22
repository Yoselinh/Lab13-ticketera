using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Clients.Query;

public class GetAllClientsQuery : IRequest<IEnumerable<Client>>
{
}

internal sealed class GetAllClientsQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetAllClientsQuery, IEnumerable<Client>>
{
    public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Client>().GetAllAsync();
    }
}