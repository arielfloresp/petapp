using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pettapp2.Models;
using System.Diagnostics;

namespace Pettapp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetappContext _context; // Agregar el contexto

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PetappContext context) // Inyectar el contexto
        {
            _logger = logger;
            _context = context; // Asignar el contexto
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Usuario()
        {
            // Consultar las adopciones del usuario con id 1
            var adopciones = await _context.Adopciones
                .Include(a => a.Mascota)
                .Where(a => a.UsuarioId == 1) // Filtrar por id de usuario
                .ToListAsync();

            // Pasar las adopciones a la vista
            ViewData["Adopciones"] = adopciones;

            return View();
        }

        // Redirigir a la vista de mascotas para adoptar
        public IActionResult Adoptar()
        {
            return RedirectToAction("VistaMascota", "Mascotas");
        }

        // Redirigir a la vista de accesorios (asumiendo que está en AccesoriosController)
        public IActionResult ComprarAccesorios()
        {
            return RedirectToAction("CompraAccesorio", "Accesorios");
        }

        // Redirigir a la vista de donaciones
        public IActionResult Donar()
        {
            return RedirectToAction("Index", "Donaciones");
        }

        public IActionResult VistaAdmin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
