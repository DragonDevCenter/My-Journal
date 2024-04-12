using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class EgresosVario
{
    public int IdEgresosvarios { get; set; }

    public int? Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaEgreso { get; set; }

    public virtual ICollection<TotalEgreso> TotalEgresos { get; set; } = new List<TotalEgreso>();
}
