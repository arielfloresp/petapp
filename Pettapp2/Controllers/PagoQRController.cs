using Microsoft.AspNetCore.Mvc;

namespace Pettapp2.Controllers
{
    public class PagoQRController : Controller
    {
        public IActionResult PagoConQR()
        {
            // Mostrar la vista de pago con QR
            return View();
        }

        // Acción para descargar la imagen del código QR
        public IActionResult DescargarQR()
        {
            var qrImagePath = "/mnt/data/QR.jpg";  // Ruta de la imagen QR
            return File(qrImagePath, "image/jpeg", "CodigoQR.jpg");
        }
    }
}
