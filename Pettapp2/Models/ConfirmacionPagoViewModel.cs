namespace Pettapp2.Models
{
    public class ConfirmacionPagoViewModel
    {
        public string CodigoTransaccion { get; set; }
        public string CuentaOrigen { get; set; }
        public string NombreBeneficiario { get; set; }
        public string NombreOrdenante { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaTransferencia { get; set; }
        public string TipoCuenta { get; set; }
    }
}
