using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Carrito;

public class SeleccionGrupo
{
    public string GrupoId { get; init; } = string.Empty;

    public IReadOnlyCollection<SeleccionOpcion> Opciones => _opciones;
    private readonly List<SeleccionOpcion> _opciones = new();
    public void AgregarOpcion(SeleccionOpcion opcion)
    {
        _opciones.Add(opcion);
    }
}

