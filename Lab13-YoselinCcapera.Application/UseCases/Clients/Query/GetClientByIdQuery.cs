using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Clients.Query;


public class GetClientByIdQuery : IRequest<Client>
{
    public int ClientId { get; set; }
}

internal sealed class GetClientByIdQueryHandler(IUnityOfWork unitOfWork) : IRequestHandler<GetClientByIdQuery, Client>
{
    public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Client>().GetByIdAsync(request.ClientId)
               ?? throw new KeyNotFoundException("Client not found");
    }
}