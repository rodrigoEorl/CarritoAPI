using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Infrastructure.DTOs;
public class InformacionCantidadJsonDto
{
    public int GroupAttributeQuantity { get; set; }
    public bool ShowPricePerProduct { get; set; }
    public bool IsShown { get; set; }
    public bool IsEditable { get; set; }
    public bool IsVerified { get; set; }
    public string VerifyValue { get; set; } // Ejemplo: "EQUAL_THAN", "LOWER_EQUAL_THAN"
}
