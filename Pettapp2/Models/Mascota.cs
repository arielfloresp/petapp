using System;
using System.Collections.Generic;

namespace Pettapp2.Models;

public partial class Mascota
{
    public int MascotaId { get; set; }

    public string Nombre { get; set; } = null!;

    public int Edad { get; set; }

    public string? Raza { get; set; }

    public string? Sexo { get; set; }

    public string? Descripcion { get; set; }

    public string? EstadoAdopcion { get; set; }

    public int RefugioId { get; set; }

    public string? ImagenUrl { get; set; } // Nueva propiedad para la URL de la imagen

    public virtual ICollection<Adopcione> Adopciones { get; set; } = new List<Adopcione>();

    public virtual Refugio Refugio { get; set; } = null!;
}
