using Carrito.Domain.Catalogo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Domain.Carrito;

public class ItemCarrito
{
    public string ProductoId { get; init; }

    public IReadOnlyCollection<SeleccionGrupo> Selecciones => _selecciones;
    private readonly List<SeleccionGrupo> _selecciones = new();

    public void AgregarSeleccion(SeleccionGrupo seleccion)
    {
        _selecciones.Add(seleccion);
    }
    public void ActualizarCantidad(string grupoId, string opcionId, int delta)
    {
        var grupo = Selecciones.Single(g => g.GrupoId == grupoId);
        var opcion = grupo.Opciones.Single(o => o.OpcionId == opcionId);

        var nuevaCantidad = opcion.Cantidad + delta;

        if (nuevaCantidad < 0)
            throw new InvalidOperationException("La cantidad no puede ser negativa");

        opcion.CambiarCantidad(nuevaCantidad);
    }
    public ItemCarrito Clonar()
    {
        var copia = new ItemCarrito { ProductoId = ProductoId };

        foreach (var grupo in Selecciones)
        {
            var g = new SeleccionGrupo { GrupoId = grupo.GrupoId };

            foreach (var opcion in grupo.Opciones)
            {
                g.AgregarOpcion(new SeleccionOpcion
                {
                    OpcionId = opcion.OpcionId,
                    Cantidad = opcion.Cantidad
                });
            }

            copia.AgregarSeleccion(g);
        }

        return copia;
    }


}

