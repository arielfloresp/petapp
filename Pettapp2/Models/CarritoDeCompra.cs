using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class CarritoDeCompra
{
    public int CarritoId { get; set; }

    public int UsuarioId { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<CarritoAccesorio> CarritoAccesorios { get; set; } = new List<CarritoAccesorio>();

    public virtual Usuario Usuario { get; set; } = null!;
}
