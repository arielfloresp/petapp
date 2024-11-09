using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class Donacione
{
    public int DonacionId { get; set; }

    public int UsuarioId { get; set; }

    public int RefugioId { get; set; }

    public decimal Monto { get; set; }

    public DateTime? FechaDonacion { get; set; }

    public virtual Refugio Refugio { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
