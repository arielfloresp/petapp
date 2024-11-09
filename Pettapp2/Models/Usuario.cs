using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RolId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Accesorio> Accesorios { get; set; } = new List<Accesorio>();

    public virtual ICollection<Adopcione> Adopciones { get; set; } = new List<Adopcione>();

    public virtual ICollection<CarritoDeCompra> CarritoDeCompras { get; set; } = new List<CarritoDeCompra>();

    public virtual ICollection<Donacione> Donaciones { get; set; } = new List<Donacione>();

    public virtual ICollection<Refugio> Refugios { get; set; } = new List<Refugio>();

    public virtual Role Rol { get; set; } = null!;
}
