using Microsoft.AspNetCore.Mvc;
using Carrito.Application.DTOs.Requests;
using Carrito.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Carrito.Api.Controllers;

[ApiController]
[Route("api/carrito")]
public class CarritoController : ControllerBase
{
    private readonly CarritoService _carritoService;

    public CarritoController(CarritoService carritoService)
    {
        _carritoService = carritoService;
    }

    [HttpPost("items")]
    public IActionResult AgregarItem([FromBody] AgregarItemCarritoRequest request)
    {
        _carritoService.AgregarItem(request);
        return Ok();
    }

    [HttpPut("items")]
    public IActionResult ActualizarItem([FromBody] AgregarItemCarritoRequest request)
    {
        _carritoService.ActualizarItem(request);
        return NoContent();
    }


    [HttpGet("items")]
    public IActionResult ObtenerCarrito()
    {
        var items = _carritoService.ObtenerCarrito();
        return Ok(items);
    }

    [HttpPatch("items/cantidad")]
    public IActionResult ActualizarCantidad([FromBody] ActualizarCantidadRequest request)
    {
        _carritoService.ActualizarCantidad(request);
        return NoContent();
    }


    [HttpDelete("items/{productoId}")]
    public IActionResult EliminarItem(string productoId)
    {
        _carritoService.EliminarItem(productoId);
        return NoContent();
    }
}

