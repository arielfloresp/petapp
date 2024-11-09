using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pettapp2.Models;

namespace Pettapp2.Controllers
{
    public class AccesoriosController : Controller
    {
        private readonly PetappContext _context;

        public AccesoriosController(PetappContext context)
        {
            _context = context;
        }
        // GET: Accesorios/Create
        [HttpGet("Accesorios/Create")]
        public IActionResult Create()
        {
            ViewData["VendedorId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre");
            return View();
        }

        // POST: Accesorios/Create
        [HttpPost("Accesorios/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccesorioId,Nombre,Descripcion,Precio,Stock,VendedorId")] Accesorio accesorio)
        {
            if (true)
            {
                _context.Add(accesorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre", accesorio.VendedorId);
            return View(accesorio);
        }


        // GET: Accesorios
        public async Task<IActionResult> Index()
        {
            var petappContext = _context.Accesorios.Include(a => a.Vendedor);
            return View(await petappContext.ToListAsync());
        }

        // Acción para agregar un accesorio al carrito de compras
        [HttpPost]
        public async Task<IActionResult> AgregarAlCarrito(int AccesorioId)
        {
            // Verifica si el accesorio existe en la base de datos
            var accesorio = await _context.Accesorios.FindAsync(AccesorioId);
            if (accesorio == null)
            {
                return NotFound("Accesorio no encontrado.");
            }

            // Lógica para obtener el carrito de compras del usuario actual
            var carrito = await ObtenerCarritoDeUsuario();

            // Verificar si el accesorio ya existe en el carrito para aumentar la cantidad
            var carritoAccesorioExistente = _context.CarritoAccesorios
                .FirstOrDefault(ca => ca.CarritoId == carrito.CarritoId && ca.AccesorioId == AccesorioId);

            if (carritoAccesorioExistente != null)
            {
                // Si ya existe en el carrito, incrementa la cantidad
                carritoAccesorioExistente.Cantidad += 1;
            }
            else
            {
                // Si no existe, agrega un nuevo accesorio al carrito
                var carritoAccesorio = new CarritoAccesorio
                {
                    AccesorioId = AccesorioId,
                    Cantidad = 1, // Inicializa la cantidad a 1
                    CarritoId = carrito.CarritoId
                };
                _context.CarritoAccesorios.Add(carritoAccesorio);
            }

            await _context.SaveChangesAsync();

            // Redirige de vuelta a la vista CompraAccesorio para mostrar todos los accesorios disponibles
            return RedirectToAction("CompraExitosa");
        }

        private async Task<CarritoDeCompra> ObtenerCarritoDeUsuario()
        {
            // Lógica para obtener el carrito de compras del usuario actual
            var usuarioId = 1; // ID del usuario que estamos usando para este ejemplo
            var carrito = await _context.CarritoDeCompras.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);

            if (carrito == null)
            {
                // Si no existe un carrito, lo creamos para el usuario
                carrito = new CarritoDeCompra { UsuarioId = usuarioId, Total = 0 };
                _context.CarritoDeCompras.Add(carrito);
                await _context.SaveChangesAsync();
            }

            return carrito;
        }

        // GET: Accesorios/Comprar/5
        public async Task<IActionResult> Comprar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorio = await _context.Accesorios.FindAsync(id);
            if (accesorio == null)
            {
                return NotFound();
            }

            return View("Compra", accesorio); // Redirige a la vista de confirmación de compra
        }

        // GET: Accesorios/CompraAccesorio
        public async Task<IActionResult> CompraAccesorio()
        {
            var petappContext = _context.Accesorios.Include(a => a.Vendedor);
            return View("CompraAccesorio", await petappContext.ToListAsync());
        }

        public async Task<IActionResult> CompraExitosa()
        {
            var petappContext = _context.Accesorios.Include(a => a.Vendedor);
            return View("CompraExitosa", await petappContext.ToListAsync());
        }

        // GET: Accesorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorio = await _context.Accesorios.FindAsync(id);
            if (accesorio == null)
            {
                return NotFound();
            }
            ViewData["VendedorId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", accesorio.VendedorId);
            return View(accesorio);
        }

        // POST: Accesorios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccesorioId,Nombre,Descripcion,Precio,Stock,VendedorId")] Accesorio accesorio)
        {
            if (id != accesorio.AccesorioId)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(accesorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccesorioExists(accesorio.AccesorioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendedorId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", accesorio.VendedorId);
            return View(accesorio);
        }

        // GET: Accesorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accesorio = await _context.Accesorios
                .Include(a => a.Vendedor)
                .FirstOrDefaultAsync(m => m.AccesorioId == id);
            if (accesorio == null)
            {
                return NotFound();
            }

            return View(accesorio);
        }

        // POST: Accesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accesorio = await _context.Accesorios.FindAsync(id);
            if (accesorio != null)
            {
                _context.Accesorios.Remove(accesorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccesorioExists(int id)
        {
            return _context.Accesorios.Any(e => e.AccesorioId == id);
        }
    }
}
