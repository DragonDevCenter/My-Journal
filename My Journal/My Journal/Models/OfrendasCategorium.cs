using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class OfrendasCategorium
{
    public int IdCatOfrenda { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Estado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<OfrendasDetalle> OfrendasDetalles { get; set; } = new List<OfrendasDetalle>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
