namespace Pettapp2.Models
{
    public class ConfirmacionPagoViewModels
    {
        public string CodigoTransaccion { get; set; }
        public string CuentaOrigen { get; set; }
        public string NombreBeneficiario { get; set; }
        public string NombreOrdenante { get; set; }
        public decimal Monto { get; set; }
        public string FechaTransferencia { get; set; }
        public string TipoCuenta { get; set; }
    }
}
