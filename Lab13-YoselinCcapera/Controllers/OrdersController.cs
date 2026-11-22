using Lab13_YoselinCcapera.Application.UseCases.Orders.Command;
using Lab13_YoselinCcapera.Application.UseCases.Orders.Query;
using Lab13_YoselinCcapera.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_YoselinCcapera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(IMediator mediator) : ControllerBase
{
    //Obtiene todas las órdenes.
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Order>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var orders = await mediator.Send(new GetAllOrdersQuery());
        return Ok(orders);
    }

    //Obtiene una orden por su id.
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await mediator.Send(new GetOrderByIdQuery { OrderId = id });
        return Ok(order);
    }

    //Crea una orden nueva.
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddOrderCommand command)
    {
        await mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    //Actualiza los datos de una orden.
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderCommand command)
    {
        command.OrderId = id;
        await mediator.Send(command);
        return NoContent();
    }

    //Elimina una orden.
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteOrderCommand { OrderId = id });
        return NoContent();
    }
}

