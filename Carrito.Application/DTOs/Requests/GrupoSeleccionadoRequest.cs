using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.DTOs.Requests;

public class GrupoSeleccionadoRequest
{
    public string GrupoId { get; set; } = string.Empty;
    public List<OpcionSeleccionadaRequest> Opciones { get; set; } = new();
}

