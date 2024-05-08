using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class OfrendasDetalle
{
    public int IdDetalle { get; set; }

    public int IdOfrenda { get; set; }

    public int IdCatOfrenda { get; set; }

    public double Cantidad { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Divisa? DivisaNavigation { get; set; }

    public virtual OfrendasCategorium IdCatOfrendaNavigation { get; set; } = null!;

    public virtual Ofrenda IdOfrendaNavigation { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
