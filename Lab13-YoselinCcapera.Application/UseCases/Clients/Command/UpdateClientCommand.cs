using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Clients.Command;


public record UpdateClientCommand : IRequest<Unit>
{
    public int ClientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

internal sealed class UpdateClientCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<UpdateClientCommand, Unit>
{
    public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Client>();

        var client = await repository.GetByIdAsync(request.ClientId)
                     ?? throw new KeyNotFoundException("Client not found");

        client.Name = request.Name;
        client.Email = request.Email;

        repository.Update(client);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}