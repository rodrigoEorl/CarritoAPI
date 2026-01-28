using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.Exceptions;
public class ExcepcionValidacionAplicacion : Exception
{
    public ExcepcionValidacionAplicacion(string mensaje)
        : base(mensaje)
    {
    }
}
