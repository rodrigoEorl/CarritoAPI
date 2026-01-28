using Carrito.Application.DTOs.Requests;
using Carrito.Application.Interfaces;
using Carrito.Application.Validators;
using Carrito.Domain.Carrito;
using Carrito.Domain.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.Services;
public class CarritoService
{
    private readonly IRepositorioProductos _repositorioProductos;
    private readonly IRepositorioCarrito _repositorioCarrito;

    public CarritoService(
        IRepositorioProductos repositorioProductos,
        IRepositorioCarrito repositorioCarrito)
    {
        _repositorioProductos = repositorioProductos;
        _repositorioCarrito = repositorioCarrito;
    }

    public void AgregarItem(AgregarItemCarritoRequest request)
    {
        // 1. Obtener producto del catálogo
        var producto = _repositorioProductos.ObtenerPorId(request.ProductoId);
        //var item = MapearADominio(request);
        // 3. Mapear request → dominio
        var itemNuevo = MapearAItemCarrito(request);

        // 2. Validar reglas de negocio
        ValidadorItemCarrito.Validar(producto, itemNuevo);


        // 4. Persistir
        _repositorioCarrito.AgregarItem(itemNuevo);
    }
    public void ActualizarItem(AgregarItemCarritoRequest request)
    {
        var producto = _repositorioProductos.ObtenerPorId(request.ProductoId);
        //var item = MapearADominio(request);
        var itemActualizado = MapearAItemCarrito(request);

        ValidadorItemCarrito.Validar(producto, itemActualizado);


        _repositorioCarrito.ActualizarItem(itemActualizado);
    }

    public IReadOnlyCollection<ItemCarrito> ObtenerCarrito()
    {
        return _repositorioCarrito.ObtenerItems();
    }

    public void ActualizarCantidad(ActualizarCantidadRequest request)
    {
        var item = _repositorioCarrito.ObtenerPorProductoId(request.ProductoId)
            ?? throw new InvalidOperationException("Producto no existe en el carrito");

        item.ActualizarCantidad(
            request.GrupoId,
            request.OpcionId,
            request.Operacion
        );

        var producto = _repositorioProductos.ObtenerPorId(request.ProductoId);

        ValidadorItemCarrito.Validar(producto, item);

        _repositorioCarrito.ActualizarItem(item);
    }


    public void EliminarItem(string productoId)
    {
        _repositorioCarrito.EliminarItem(productoId);
    }

    private static ItemCarrito MapearAItemCarrito(AgregarItemCarritoRequest request)
    {
        var item = new ItemCarrito
        {
            ProductoId = request.ProductoId
        };

        foreach (var grupoReq in request.Grupos)
        {
            var seleccionGrupo = new SeleccionGrupo
            {
                GrupoId = grupoReq.GrupoId
            };

            foreach (var opcionReq in grupoReq.Opciones)
            {
                seleccionGrupo.AgregarOpcion(new SeleccionOpcion
                {
                    OpcionId = opcionReq.OpcionId,
                    Cantidad = opcionReq.Cantidad
                });
            }

            item.AgregarSeleccion(seleccionGrupo);
        }

        return item;
    }
}
