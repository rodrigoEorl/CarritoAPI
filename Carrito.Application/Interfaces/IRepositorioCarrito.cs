using Carrito.Domain.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.Interfaces;
public interface IRepositorioCarrito
{
    void AgregarItem(ItemCarrito item);
    void ActualizarItem(ItemCarrito item);
    IReadOnlyCollection<ItemCarrito> ObtenerItems();
    ItemCarrito ObtenerPorProductoId(string productoId);
    void EliminarItem(string productoId);
}
