using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class Refugio
{
    public int RefugioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public int UsuarioId { get; set; }

    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual Usuario Usuario { get; set; } = null!;
}
