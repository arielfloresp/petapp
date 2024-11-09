using Microsoft.AspNetCore.Mvc;
using Pettapp2.Models;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class PagoController : Controller
{
    private readonly PetappContext _context;

    public PagoController(PetappContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SeleccionarMetodoPago(string paymentMethod)
    {
        if (paymentMethod == "creditCard")
        {
            return RedirectToAction("PagoConTarjeta");
        }
        else if (paymentMethod == "qr")
        {
            return RedirectToAction("PagoConQR");
        }

        return RedirectToAction("Checkout");
    }

    [HttpGet]
    public IActionResult PagoConTarjeta()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ProcesarPagoConTarjeta(string cardName, string cardNumber, string expiryDate, string cvv, string billingAddress)
    {
        return View("ConfirmacionPago");
    }

    [HttpGet]
    public IActionResult PagoConQR()
    {
        var model = new PagoQRViewModel
        {
            NombreAccesorio = "Collar para perro",
            PrecioAccesorio = 50.00m,
            FechaCompra = DateTime.Now.ToString("MM/dd/yyyy")
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult FormularioConfirmacion()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> EnviarConfirmacion(string nombre, string apellido, string bancoDestino, string numeroTransaccion, decimal montoAbonado, IFormFile comprobantePago)
    {
        string filePath = null;

        if (comprobantePago != null && comprobantePago.Length > 0)
        {
            var directoryPath = Path.Combine("wwwroot/comprobantes");
            Directory.CreateDirectory(directoryPath);

            var fileName = Guid.NewGuid() + Path.GetExtension(comprobantePago.FileName);
            filePath = Path.Combine("/comprobantes", fileName);

            using (var stream = new FileStream(Path.Combine(directoryPath, fileName), FileMode.Create))
            {
                await comprobantePago.CopyToAsync(stream);
            }
        }

        var confirmacion = new ConfirmacionCompra
        {
            Nombre = nombre,
            Apellido = apellido,
            BancoDestino = bancoDestino,
            NumeroTransaccion = numeroTransaccion,
            MontoAbonado = montoAbonado,
            ComprobantePath = filePath,
            Fecha = DateTime.Now,
            PagoValidado = false, // Inicialmente, el pago no está validado
            EnvioCompletado = false // Inicialmente, el envío no está completado
        };

        _context.ConfirmacionesCompra.Add(confirmacion);
        await _context.SaveChangesAsync();

        return RedirectToAction("GraciasPorSuCompra");
    }

    [HttpGet]
    public IActionResult GraciasPorSuCompra()
    {
        return View();
    }

    [HttpGet]
    public IActionResult ConfirmacionesDeCompra()
    {
        var confirmaciones = _context.ConfirmacionesCompra.ToList();
        return View(confirmaciones);
    }

    public IActionResult DescargarComprobante(string filePath)
    {
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath.TrimStart('/'));

        if (!System.IO.File.Exists(fullPath))
        {
            return NotFound("El comprobante no se encuentra.");
        }

        var fileName = Path.GetFileName(fullPath);
        return PhysicalFile(fullPath, "application/octet-stream", fileName);
    }

    [HttpPost]
    public IActionResult ValidarPago(int id)
    {
        var confirmacion = _context.ConfirmacionesCompra.FirstOrDefault(c => c.ConfirmacionCompraId == id);
        if (confirmacion != null)
        {
            confirmacion.PagoValidado = true;
            _context.SaveChanges();
            return Ok();
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult CompletarEnvio(int id)
    {
        var confirmacion = _context.ConfirmacionesCompra.FirstOrDefault(c => c.ConfirmacionCompraId == id);
        if (confirmacion != null)
        {
            confirmacion.EnvioCompletado = true;
            _context.SaveChanges();
            return Ok();
        }
        return NotFound();
    }

    [HttpPost]
    public IActionResult BorrarCache()
    {
        var confirmaciones = _context.ConfirmacionesCompra.ToList();
        _context.ConfirmacionesCompra.RemoveRange(confirmaciones);
        _context.SaveChanges();

        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/comprobantes");
        if (Directory.Exists(directoryPath))
        {
            var files = Directory.GetFiles(directoryPath);
            foreach (var file in files)
            {
                System.IO.File.Delete(file);
            }
        }
        return Ok();
    }

    public IActionResult DescargarQR()
    {
        var qrImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", "QR.jpg");

        if (!System.IO.File.Exists(qrImagePath))
        {
            return NotFound("El archivo no se encuentra.");
        }

        return PhysicalFile(qrImagePath, "image/jpeg", "CodigoQR.jpg");
    }
}
