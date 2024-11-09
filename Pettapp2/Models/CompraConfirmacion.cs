namespace Pettapp2.Models
{
    public class CompraConfirmacion
    {
        public int Id { get; set; }  // ID único para cada confirmación
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string BancoDestino { get; set; }
        public string NumeroTransaccion { get; set; }
        public decimal MontoAbonado { get; set; }
        public string ComprobantePath { get; set; }  // Ruta del comprobante de pago guardado
        public DateTime FechaCompra { get; set; }    // Fecha en que se realizó la compra
    }
}
