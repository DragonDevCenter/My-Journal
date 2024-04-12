using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class DetOfrendaCategorium
{
    public int? IdOfrendas { get; set; }

    public int? IdCategoria { get; set; }

    public virtual CategoriaOfrenda? IdCategoriaNavigation { get; set; }

    public virtual Ofrenda? IdOfrendasNavigation { get; set; }
}
