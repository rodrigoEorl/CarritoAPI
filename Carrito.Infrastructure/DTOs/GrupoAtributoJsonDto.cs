using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carrito.Infrastructure.DTOs;
public class GrupoAtributoJsonDto
{
    public string GroupAttributeId { get; set; }
    public TipoGrupoJsonDto GroupAttributeType { get; set; }
    public string Description { get; set; }
    public InformacionCantidadJsonDto QuantityInformation { get; set; }
    public List<AtributoOpcionJsonDto> Attributes { get; set; }
    public int Order { get; set; }
}
