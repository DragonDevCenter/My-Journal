using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class Diezmo
{
    public int IdDiezmo { get; set; }

    public string? NombrePersonaDiezmo { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? FechaDiezmo { get; set; }

    public virtual ICollection<TotalIngreso> TotalIngresos { get; set; } = new List<TotalIngreso>();
}
