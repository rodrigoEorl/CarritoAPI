using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.DTOs.Requests;

public class AgregarItemCarritoRequest
{
    public string ProductoId { get; set; }
    public List<GrupoSeleccionadoRequest> Grupos { get; set; } = new();
}
