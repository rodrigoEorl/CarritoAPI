using Carrito.Domain.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.Interfaces;
public interface IRepositorioProductos
{
    Producto ObtenerPorId(string productoId);
}
