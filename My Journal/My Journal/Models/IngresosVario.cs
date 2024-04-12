using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class IngresosVario
{
    public int IdVarios { get; set; }

    public int? Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? FechaVarios { get; set; }

    public virtual ICollection<TotalIngreso> TotalIngresos { get; set; } = new List<TotalIngreso>();
}
