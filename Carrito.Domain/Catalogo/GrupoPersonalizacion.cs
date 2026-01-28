using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Catalogo;

public class GrupoPersonalizacion
{
    public string GrupoId { get; init; } = string.Empty;
    public string Nombre { get; init; } = string.Empty;
    public ReglaCantidadGrupo ReglaCantidad { get; init; } = default!;

    public IReadOnlyCollection<OpcionPersonalizacion> Opciones => _opciones;
    private readonly List<OpcionPersonalizacion> _opciones = new();

    public void AgregarOpcion(OpcionPersonalizacion opcion)
    {
        _opciones.Add(opcion);
    }
}

