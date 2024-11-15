﻿using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class Accesorio
{
    public int AccesorioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int VendedorId { get; set; }

    public virtual ICollection<CarritoAccesorio> CarritoAccesorios { get; set; } = new List<CarritoAccesorio>();

    public virtual Usuario Vendedor { get; set; } = null!;
}
