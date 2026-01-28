using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Infrastructure.DTOs;
public class ProductoJsonDto
{
    public string ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<GrupoAtributoJsonDto> GroupAttributes { get; set; } = new();
}
