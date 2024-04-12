using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class PagosBasico
{
    public int IdPagos { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? FechaPago { get; set; }

    public virtual ICollection<TotalEgreso> TotalEgresos { get; set; } = new List<TotalEgreso>();
}
