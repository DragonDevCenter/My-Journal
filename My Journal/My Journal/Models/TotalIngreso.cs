using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class TotalIngreso
{
    public int IdTotalIngresos { get; set; }

    public double? TotalIngreso1 { get; set; }

    public string? MesIngresos { get; set; }

    public int? IdOfrendas { get; set; }

    public int? IdDiezmo { get; set; }

    public int? IdVarios { get; set; }

    public virtual Diezmo? IdDiezmoNavigation { get; set; }

    public virtual Ofrenda? IdOfrendasNavigation { get; set; }

    public virtual IngresosVario? IdVariosNavigation { get; set; }

    public virtual ICollection<Total> Totals { get; set; } = new List<Total>();
}
