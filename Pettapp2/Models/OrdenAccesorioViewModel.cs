namespace Pettapp2.Models
{
    public class OrdenAccesorioViewModel
    {
        public string NombreAccesorio { get; set; }
        public string NombreUsuario { get; set; }  // Agregar esta propiedad
        public DateTime FechaCompra { get; set; }  // Agregar esta propiedad
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
