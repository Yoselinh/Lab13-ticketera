using Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Command;
using Lab13_YoselinCcapera.Application.UseCases.OrderDetails.Query;
using Lab13_YoselinCcapera.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_YoselinCcapera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController(IMediator mediator) : ControllerBase
{
    //Obtiene todos los detalles de orden.
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Orderdetail>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var orderDetails = await mediator.Send(new GetAllOrderDetailsQuery());
        return Ok(orderDetails);
    }

    //Obtiene un detalle de orden por su id.
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Orderdetail), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var orderDetail = await mediator.Send(new GetOrderDetailByIdQuery { OrderDetailId = id });
        return Ok(orderDetail);
    }

    //Crea un detalle de orden nuevo.
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddOrderDetailCommand command)
    {
        await mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    //Actualiza los datos de un detalle de orden.
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDetailCommand command)
    {
        command.OrderDetailId = id;
        await mediator.Send(command);
        return NoContent();
    }

    //Elimina un detalle de orden.
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteOrderDetailCommand { OrderDetailId = id });
        return NoContent();
    }
}

