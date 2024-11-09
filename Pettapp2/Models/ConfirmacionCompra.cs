namespace Pettapp2.Models
{
    public class ConfirmacionCompra
    {
        public int ConfirmacionCompraId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string BancoDestino { get; set; }
        public string NumeroTransaccion { get; set; }
        public decimal MontoAbonado { get; set; }
        public string ComprobantePath { get; set; }
        public DateTime Fecha { get; set; }
        public bool PagoValidado { get; set; }
        public bool EnvioCompletado { get; set; } // Nueva propiedad para el estado de envío

    }
}
