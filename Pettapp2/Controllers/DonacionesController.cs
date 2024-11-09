using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pettapp2.Models;

namespace Pettapp2.Controllers
{
    public class DonacionesController : Controller
    {
        private readonly PetappContext _context;

        public DonacionesController(PetappContext context)
        {
            _context = context;
        }

        // GET: Donaciones
        public async Task<IActionResult> Index()
        {
            var petappContext = _context.Donaciones.Include(d => d.Refugio).Include(d => d.Usuario);
            return View(await petappContext.ToListAsync());
        }

        // GET: Donaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donacione = await _context.Donaciones
                .Include(d => d.Refugio)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.DonacionId == id);
            if (donacione == null)
            {
                return NotFound();
            }

            return View(donacione);
        }

        // GET: Donaciones/Create
        public IActionResult Create()
        {
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "RefugioId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Donaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonacionId,UsuarioId,RefugioId,Monto,FechaDonacion")] Donacione donacione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donacione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "RefugioId", donacione.RefugioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", donacione.UsuarioId);
            return View(donacione);
        }

        // GET: Donaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donacione = await _context.Donaciones.FindAsync(id);
            if (donacione == null)
            {
                return NotFound();
            }
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "RefugioId", donacione.RefugioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", donacione.UsuarioId);
            return View(donacione);
        }

        // POST: Donaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonacionId,UsuarioId,RefugioId,Monto,FechaDonacion")] Donacione donacione)
        {
            if (id != donacione.DonacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donacione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonacioneExists(donacione.DonacionId))
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
            ViewData["RefugioId"] = new SelectList(_context.Refugios, "RefugioId", "RefugioId", donacione.RefugioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", donacione.UsuarioId);
            return View(donacione);
        }

        // GET: Donaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donacione = await _context.Donaciones
                .Include(d => d.Refugio)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(m => m.DonacionId == id);
            if (donacione == null)
            {
                return NotFound();
            }

            return View(donacione);
        }

        // POST: Donaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donacione = await _context.Donaciones.FindAsync(id);
            if (donacione != null)
            {
                _context.Donaciones.Remove(donacione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonacioneExists(int id)
        {
            return _context.Donaciones.Any(e => e.DonacionId == id);
        }
    }
}
