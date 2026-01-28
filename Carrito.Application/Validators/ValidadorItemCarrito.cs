using Carrito.Application.DTOs.Requests;
using Carrito.Application.Exceptions;
using Carrito.Domain.Carrito;
using Carrito.Domain.Catalogo;
using Carrito.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Application.Validators;
public class ValidadorItemCarrito
{
    public static void Validar(Producto producto, ItemCarrito item)
    {
        // 1. Consistencia de grupos
        var gruposCatalogo = producto.Grupos.ToDictionary(g => g.GrupoId);

        foreach (var grupoSel in item.Selecciones)
        {
            if (!gruposCatalogo.ContainsKey(grupoSel.GrupoId))
                throw new ExcepcionValidacionAplicacion(
                    $"El grupo '{grupoSel.GrupoId}' no existe para este producto.");
        }

        // 2. Grupos obligatorios
        foreach (var grupo in producto.Grupos)
        {
            if (grupo.ReglaCantidad.TipoVerificacion == TipoVerificacionCantidad.EqualThan)
            {
                var grupoSel = item.Selecciones.FirstOrDefault(g => g.GrupoId == grupo.GrupoId);

                if (grupoSel is null)
                    throw new ExcepcionValidacionAplicacion(
                        $"El grupo '{grupo.Nombre}' es obligatorio.");
            }
        }

        // 3. Cantidad por grupo
        foreach (var grupoSel in item.Selecciones)
        {
            var grupoCatalogo = gruposCatalogo[grupoSel.GrupoId];
            var totalSeleccionado = grupoSel.Opciones.Sum(o => o.Cantidad);

            var max = grupoCatalogo.ReglaCantidad.CantidadPermitida;

            if (grupoCatalogo.ReglaCantidad.TipoVerificacion == TipoVerificacionCantidad.EqualThan &&
                totalSeleccionado != max)
                throw new ExcepcionValidacionAplicacion(
                    $"El grupo '{grupoCatalogo.Nombre}' requiere exactamente {max} selecciones.");

            if (grupoCatalogo.ReglaCantidad.TipoVerificacion == TipoVerificacionCantidad.LowerEqualThan &&
                totalSeleccionado > max)
                throw new ExcepcionValidacionAplicacion(
                    $"El grupo '{grupoCatalogo.Nombre}' permite como máximo {max} selecciones.");
        }

        // 4. Consistencia de opciones + 5. Cantidad por opción
        foreach (var grupoSel in item.Selecciones)
        {
            var grupoCatalogo = gruposCatalogo[grupoSel.GrupoId];
            var opcionesCatalogo = grupoCatalogo.Opciones.ToDictionary(o => o.OpcionId);

            foreach (var opcionSel in grupoSel.Opciones)
            {
                if (!opcionesCatalogo.ContainsKey(opcionSel.OpcionId))
                    throw new ExcepcionValidacionAplicacion(
                        $"La opción '{opcionSel.OpcionId}' no pertenece al grupo '{grupoCatalogo.Nombre}'.");

                var opcionCatalogo = opcionesCatalogo[opcionSel.OpcionId];

                if (opcionSel.Cantidad <= 0)
                    throw new ExcepcionValidacionAplicacion(
                        $"Cantidad inválida para la opción '{opcionCatalogo.Nombre}'.");

                if (opcionSel.Cantidad > opcionCatalogo.MaxCantidad)
                    throw new ExcepcionValidacionAplicacion(
                        $"La opción '{opcionCatalogo.Nombre}' permite máximo {opcionCatalogo.MaxCantidad}.");
            }
        }
    }


}
