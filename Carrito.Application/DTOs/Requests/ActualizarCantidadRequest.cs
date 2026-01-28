using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.DTOs.Requests;
public class ActualizarCantidadRequest
{
    public string ProductoId { get; init; } = string.Empty;
    public string GrupoId { get; init; } = string.Empty;
    public string OpcionId { get; init; } = string.Empty;
    public int Operacion { get; init; } // +1 o -1
}

