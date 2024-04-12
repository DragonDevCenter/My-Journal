using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class TotalEgreso
{
    public int IdTotalEgresos { get; set; }

    public double? TotalEgreso1 { get; set; }

    public string? MesEgreso { get; set; }

    public int? IdOfrendaPastoral { get; set; }

    public int? IdEgresosvarios { get; set; }

    public int? IdPagos { get; set; }

    public virtual EgresosVario? IdEgresosvariosNavigation { get; set; }

    public virtual OfrendaPastoral? IdOfrendaPastoralNavigation { get; set; }

    public virtual PagosBasico? IdPagosNavigation { get; set; }

    public virtual ICollection<Total> Totals { get; set; } = new List<Total>();
}
