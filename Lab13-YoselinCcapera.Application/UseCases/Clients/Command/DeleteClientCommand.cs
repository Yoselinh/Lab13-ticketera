using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Clients.Command;

public record DeleteClientCommand : IRequest<Unit>
{
    public int ClientId { get; set; }
}

internal sealed class DeleteClientCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<DeleteClientCommand, Unit>
{
    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<Client>();

        var client = await repository.GetByIdAsync(request.ClientId)
                     ?? throw new KeyNotFoundException("Client not found");

        repository.Delete(client);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}