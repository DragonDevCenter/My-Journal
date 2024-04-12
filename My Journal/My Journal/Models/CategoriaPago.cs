using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class CategoriaPago
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }
}
