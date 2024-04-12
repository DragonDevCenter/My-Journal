using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class Ofrenda
{
    public int IdOfrendas { get; set; }

    public int? Cantidad { get; set; }

    public DateOnly? FechaOfrenda { get; set; }

    public virtual ICollection<TotalIngreso> TotalIngresos { get; set; } = new List<TotalIngreso>();
}
