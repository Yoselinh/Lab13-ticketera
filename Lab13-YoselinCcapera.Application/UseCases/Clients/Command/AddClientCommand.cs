using Lab13_YoselinCcapera.Domain.Models;
using Lab13_YoselinCcapera.Domain.Ports.Repositories;
using MediatR;

namespace Lab13_YoselinCcapera.Application.UseCases.Clients.Command;

public record AddClientCommand : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

internal sealed class AddClientCommandHandler(IUnityOfWork unitOfWork) : IRequestHandler<AddClientCommand, Unit>
{
    public async Task<Unit> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Client
        {
            Name = request.Name,
            Email = request.Email
        };

        await unitOfWork.Repository<Client>().AddAsync(client);
        await unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}
