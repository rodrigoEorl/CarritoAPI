using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Catalogo;

public class Producto
{
    public string ProductoId { get; init; }
    public string Nombre { get; init; } = string.Empty;
    public decimal PrecioBase { get; init; }

    public IReadOnlyCollection<GrupoPersonalizacion> Grupos => _grupos;
    private readonly List<GrupoPersonalizacion> _grupos = new();

    public void AgregarGrupo(GrupoPersonalizacion grupo)
    {
        _grupos.Add(grupo);
    }
}

