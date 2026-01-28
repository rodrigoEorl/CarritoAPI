using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Catalogo;

public class OpcionPersonalizacion
{
    public string OpcionId { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public int MaxCantidad { get; init; }
    public decimal PrecioAdicional { get; init; } 
}

