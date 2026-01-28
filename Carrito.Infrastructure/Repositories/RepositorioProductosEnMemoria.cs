using Carrito.Application.Interfaces;
using Carrito.Domain.Catalogo;
using Carrito.Domain.Enums;
using Carrito.Infrastructure.DTOs;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Carrito.Infrastructure.Repositories;
public class RepositorioProductosEnMemoria : IRepositorioProductos
{
    private readonly List<Producto> _productos;

    public RepositorioProductosEnMemoria(IHostEnvironment env)
    {
        var path = Path.Combine(
            env.ContentRootPath,
            "Data",
            "productos.json"
        );
        var json = File.ReadAllText(path);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        var productosDto = JsonSerializer.Deserialize<List<ProductoJsonDto>>(json, options)
                            ?? new List<ProductoJsonDto>();

        _productos = productosDto.Select(MapearADominio).ToList();
    }

    public Producto ObtenerPorId(string id)
    {
        return _productos.FirstOrDefault(p => p.ProductoId == id)
               ?? throw new Exception("Producto no encontrado");
    }
    private static TipoVerificacionCantidad MapearTipo(string verifyValue)
    {
        return verifyValue switch
        {
            "EQUAL_THAN" => TipoVerificacionCantidad.EqualThan,
            "LOWER_EQUAL_THAN" => TipoVerificacionCantidad.LowerEqualThan,
            _ => throw new InvalidOperationException($"Tipo de verificación no soportado: {verifyValue}")
        };
    }

    private static ReglaCantidadGrupo MapearRegla(GrupoAtributoJsonDto dto)
    {
        return new ReglaCantidadGrupo
        {
            CantidadPermitida = dto.QuantityInformation.GroupAttributeQuantity,
            TipoVerificacion = MapearTipo(dto.QuantityInformation.VerifyValue)
        };
    }
    private static Producto MapearADominio(ProductoJsonDto dto)
    {
        var producto = new Producto
        {
            ProductoId = dto.ProductId,
            Nombre = dto.Name,
            PrecioBase = dto.Price
        };

        foreach (var grupoDto in dto.GroupAttributes)
        {
            var grupo = new GrupoPersonalizacion
            {
                GrupoId = grupoDto.GroupAttributeId,
                Nombre = grupoDto.Description,
                ReglaCantidad = MapearRegla(grupoDto)
            };

            foreach (var opcionDto in grupoDto.Attributes)
            {
                grupo.AgregarOpcion(new OpcionPersonalizacion
                {
                    OpcionId = opcionDto.AttributeId,
                    Nombre = opcionDto.Name,
                    MaxCantidad = opcionDto.MaxQuantity,
                    PrecioAdicional = opcionDto.PriceImpactAmount
                });
            }

            producto.AgregarGrupo(grupo);
        }

        return producto;
    }

}
