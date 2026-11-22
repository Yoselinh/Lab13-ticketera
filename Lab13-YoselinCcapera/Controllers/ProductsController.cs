using Lab13_YoselinCcapera.Application.UseCases.Products.Command;
using Lab13_YoselinCcapera.Application.UseCases.Products.Query;
using Lab13_YoselinCcapera.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab13_YoselinCcapera.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    //Obtiene todos los productos
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var products = await mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    //Obtiene un producto por su id
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await mediator.Send(new GetProductByIdQuery { ProductId = id });
        return Ok(product);
    }

    //Crea un producto nuevo
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] AddProductCommand command)
    {
        await mediator.Send(command);
        return StatusCode(StatusCodes.Status201Created);
    }

    //Actualiza los datos de un producto
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
    {
        command.ProductId = id;
        await mediator.Send(command);
        return NoContent();
    }

    /// <summary>Elimina un producto.</summary>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteProductCommand { ProductId = id });
        return NoContent();
    }
}