using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class Adopcione
{
    public int AdopcionId { get; set; }

    public int UsuarioId { get; set; }

    public int MascotaId { get; set; }

    public DateTime? FechaAdopcion { get; set; }

    public virtual Mascota Mascota { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
