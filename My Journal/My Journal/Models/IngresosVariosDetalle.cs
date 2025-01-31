﻿using System;
using System.Collections.Generic;

namespace My_Journal;

public partial class IngresosVariosDetalle
{
    public int IdDetalle { get; set; }

    public int IdIngreVarios { get; set; }

    public int? IdMiembro { get; set; }

    public double Cantidad { get; set; }

    public int? Divisa { get; set; }

    public double? TasaCambio { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual Divisa? DivisaNavigation { get; set; }

    public virtual IngresosVario IdIngreVariosNavigation { get; set; } = null!;

    public virtual Miembro? IdMiembroNavigation { get; set; }

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
