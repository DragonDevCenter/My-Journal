using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class DetPagocategorium
{
    public int? IdPago { get; set; }

    public int? IdCategoria { get; set; }

    public virtual CategoriaPago? IdCategoriaNavigation { get; set; }

    public virtual PagosBasico? IdPagoNavigation { get; set; }
}
