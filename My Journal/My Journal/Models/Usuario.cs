using System;
using System.Collections.Generic;

namespace My_Journal.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Clave { get; set; }

    public bool? EsActivo { get; set; }

    public DateOnly? FechaRegistro { get; set; }
}
