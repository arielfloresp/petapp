using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pettapp2.Models;

namespace Pettapp2.Controllers
{
    public class MascotasController : Controller
    {
        private readonly PetappContext _context;

        public MascotasController(PetappContext context)
        {
            _context = context;
        }

        // GET: Mascotas/Index
        public async Task<IActionResult> Index()
        {
            var petappContext = _context.Mascotas.Include(m => m.Refugio);
            return View(await petappContext.ToListAsync());
        }



        // GET: Mascotas/VistaMascota
        public async Task<IActionResult> VistaMascota(int? edadFiltro)
        {
            var mascotas = await _context.Mascotas
                .Include(m => m.Refugio)
                .ToListAsync();

            // Aplicar el filtro de edad si es proporcionado
            if (edadFiltro.HasValue)
            {
                mascotas = mascotas.Where(m => m.Edad == edadFiltro.Value).ToList();
            }

            return View("VistaMascota", mascotas);
        }



        // GET: Mascotas/DetailsMascota/5
        public async Task<IActionResult> DetailsMascota(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Refugio)
                .FirstOrDefaultAsync(m => m.MascotaId == id);
            if (mascota == null)
            {
                return NotFound();
            }

            // Preparar datos de adopción para el formulario
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Nombre");

            return View("DetailsMascota", mascota);
        }

        // POST: Mascotas/Adoptar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adoptar(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }

            // Cambiar el estado de la mascota a "Adoptado"
            mascota.EstadoAdopcion = "Adoptado";

            // Crear el registro de adopción
            var adopcion = new Adopcione
            {
                MascotaId = mascota.MascotaId,
                UsuarioId = 1,  // Aquí deberías poner el ID del usuario que está adoptando (deberías obtenerlo del contexto de autenticación)
                FechaAdopcion = DateTime.Now
            };

            // Guardar la adopción en la base de datos
            _context.Adopciones.Add(adopcion);

            // Actualizar el estado de la mascota
            _context.Update(mascota);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Redirigir a la lista de mascotas disponibles después de la adopción
            return RedirectToAction(nameof(VistaMascota));
        }


        // GET: Mascotas/Create
        public IActionResult Create()
        {
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MascotaId,Nombre,Edad,Raza,Sexo,Descripcion,RefugioId")] Mascota mascota, IFormFile ImagenArchivo)
        {
            if (true)
            {
                if (ImagenArchivo != null && ImagenArchivo.Length > 0)
                {
                    // Guardar la imagen
                    var rutaCarpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes");
                    if (!Directory.Exists(rutaCarpeta))
                    {
                        Directory.CreateDirectory(rutaCarpeta);
                    }

                    var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(ImagenArchivo.FileName);
                    var rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                    using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        await ImagenArchivo.CopyToAsync(stream);
                    }

                    mascota.ImagenUrl = "/imagenes/" + nombreArchivo;
                }

                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "Nombre", mascota.RefugioId);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "Nombre", mascota.RefugioId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MascotaId,Nombre,Edad,Raza,Sexo,Descripcion,EstadoAdopcion,RefugioId,ImagenUrl")] Mascota mascota)
        {
            if (id != mascota.MascotaId)
            {
                return NotFound();
            }

            if (true)
            {
                try
                {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.MascotaId))
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
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "Nombre", mascota.RefugioId);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Refugio)
                .FirstOrDefaultAsync(m => m.MascotaId == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.MascotaId == id);
        }

        // Método para ver detalles de la mascota (llamado Details)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.Refugio)
                .FirstOrDefaultAsync(m => m.MascotaId == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);  // Asegúrate de que esté retornando la vista correcta
        }
    }
}
