using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Infrastructure.DTOs;
public class AtributoOpcionJsonDto
{
    public string ProductId { get; set; }
    public string AttributeId { get; set; }
    public string Name { get; set; }
    public int DefaultQuantity { get; set; }
    public int MaxQuantity { get; set; }
    public decimal PriceImpactAmount { get; set; }
    public bool IsRequired { get; set; }
    public string NegativeAttributeId { get; set; }
    public int Order { get; set; }
    public string StatusId { get; set; }
    public string UrlImage { get; set; }
}
