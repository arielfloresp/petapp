using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class CarritoAccesorio
{
    public int CarritoAccesorioId { get; set; }

    public int CarritoId { get; set; }

    public int AccesorioId { get; set; }

    public int Cantidad { get; set; }

    public virtual Accesorio Accesorio { get; set; } = null!;

    public virtual CarritoDeCompra Carrito { get; set; } = null!;
}
