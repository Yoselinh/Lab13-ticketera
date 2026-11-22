using Lab13_YoselinCcapera.Application.UseCases.Clients.Command;
using Lab13_YoselinCcapera.Application.UseCases.Clients.Query;
using Lab13_YoselinCcapera.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_YoselinCcapera.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ClientsController(IMediator mediator) : ControllerBase
{
    //obtiene todos los clientes.
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Client>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var clients = await mediator.Send(new GetAllClientsQuery());
        return Ok(clients);
    }

    // Obtiene un cliente por su id
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await mediator.Send(new GetClientByIdQuery { ClientId = id });
        return Ok(client);
    }

    //Crea un cliente nuevo.
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddClientCommand command)
    {
        await mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    //Actualiza los datos de un cliente.
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClientCommand command)
    {
        command.ClientId = id;
        await mediator.Send(command);
        return NoContent();
    }

    //Elimina un cliente.
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteClientCommand { ClientId = id });
        return NoContent();
    }
}