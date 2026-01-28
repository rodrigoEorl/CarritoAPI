using Carrito.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Catalogo;

public class ReglaCantidadGrupo
{
    public int CantidadPermitida { get; init; }
    public TipoVerificacionCantidad TipoVerificacion { get; init; }
}

