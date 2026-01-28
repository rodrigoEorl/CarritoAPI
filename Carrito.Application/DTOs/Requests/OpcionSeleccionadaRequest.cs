using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.DTOs.Requests;

public class OpcionSeleccionadaRequest
{
    public string OpcionId { get; set; }
    public int Cantidad { get; set; }
}
