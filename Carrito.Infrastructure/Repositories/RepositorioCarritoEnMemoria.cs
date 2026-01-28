using Carrito.Application.Interfaces;
using Carrito.Domain.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Infrastructure.Repositories;
public class RepositorioCarritoEnMemoria : IRepositorioCarrito
{
    private static readonly List<ItemCarrito> _items = new();

    public void AgregarItem(ItemCarrito item)
    {
        _items.Add(item);
    }
    public void ActualizarItem(ItemCarrito item)
    {
        var existente = _items.FirstOrDefault(x => x.ProductoId == item.ProductoId);

        if (existente == null)
            throw new InvalidOperationException("El producto no existe en el carrito");

        _items.Remove(existente);
        _items.Add(item);
    }


    public IReadOnlyCollection<ItemCarrito> ObtenerItems()
    {
        return _items.AsReadOnly();
    }
    public ItemCarrito ObtenerPorProductoId(string productoId)
    {
        var producto = _items.FirstOrDefault(x => x.ProductoId == productoId);
        if (producto == null)
            throw new InvalidOperationException("El producto no existe en el carrito");

        return producto;
    }

    public void EliminarItem(string productoId)
    {
        var item = _items.FirstOrDefault(x => x.ProductoId == productoId);
        if (item != null)
        {
            _items.Remove(item);
        }
    }
}
