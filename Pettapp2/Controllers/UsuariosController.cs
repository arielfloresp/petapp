using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pettapp2.Models;

namespace Pettapp2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly PetappContext _context;

        public UsuarioController(PetappContext context)
        {
            _context = context;
        }

        // GET: Usuario/Perfil
        public async Task<IActionResult> Perfil(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.CarritoDeCompras)
                .Include(u => u.Adopciones)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/ConfirmarCompra
        public async Task<IActionResult> ConfirmarCompra(int? accesorioId, int cantidad)
        {
            if (accesorioId == null || cantidad <= 0)
            {
                return BadRequest();
            }

            var accesorio = await _context.Accesorios.FindAsync(accesorioId);

            if (accesorio == null || accesorio.Stock < cantidad)
            {
                // Mostrar un error si el accesorio no existe o no hay suficiente stock
                return View("ErrorCompra");
            }

            ViewData["Cantidad"] = cantidad;
            return View(accesorio);
        }

        // POST: Usuario/RealizarCompra
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealizarCompra(int accesorioId, int cantidad)
        {
            var accesorio = await _context.Accesorios.FindAsync(accesorioId);

            if (accesorio == null || cantidad > accesorio.Stock)
            {
                // Mostrar un mensaje de error si el accesorio no existe o si la cantidad es mayor al stock disponible
                return RedirectToAction("ConfirmarCompra", new { accesorioId = accesorioId, cantidad = cantidad });
            }

            // Actualizar el stock del accesorio
            accesorio.Stock -= cantidad;
            _context.Update(accesorio);
            await _context.SaveChangesAsync();

            // Redirigir a la página de compra exitosa
            return RedirectToAction("CompraExitosa");
        }

        // GET: Usuario/CompraExitosa
        public IActionResult CompraExitosa()
        {
            return View();
        }
    }
}
