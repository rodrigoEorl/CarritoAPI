using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Carrito;

public class SeleccionOpcion
{
    public string OpcionId { get; init; }
    public int Cantidad { get; set; }
    public void CambiarCantidad(int cantidad)
    {
        this.Cantidad = cantidad;
    }
}

