﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pettapp2.Models;

namespace Pettapp2.Controllers
{
    public class AdopcionesController : Controller
    {
        private readonly PetappContext _context;

        public AdopcionesController(PetappContext context)
        {
            _context = context;
        }

        // GET: Adopciones
        public async Task<IActionResult> Index()
        {
            var petappContext = _context.Adopciones.Include(a => a.Mascota).Include(a => a.Usuario);
            return View(await petappContext.ToListAsync());
        }

        // GET: Adopciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcione = await _context.Adopciones
                .Include(a => a.Mascota)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AdopcionId == id);
            if (adopcione == null)
            {
                return NotFound();
            }

            return View(adopcione);
        }

        // GET: Adopciones/Create
        public IActionResult Create()
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "MascotaId", "MascotaId");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId");
            return View();
        }

        // POST: Adopciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdopcionId,UsuarioId,MascotaId,FechaAdopcion")] Adopcione adopcione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopcione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "MascotaId", "MascotaId", adopcione.MascotaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", adopcione.UsuarioId);
            return View(adopcione);
        }

        // GET: Adopciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcione = await _context.Adopciones.FindAsync(id);
            if (adopcione == null)
            {
                return NotFound();
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "MascotaId", "MascotaId", adopcione.MascotaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", adopcione.UsuarioId);
            return View(adopcione);
        }

        // POST: Adopciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdopcionId,UsuarioId,MascotaId,FechaAdopcion")] Adopcione adopcione)
        {
            if (id != adopcione.AdopcionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopcione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopcioneExists(adopcione.AdopcionId))
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
            ViewData["MascotaId"] = new SelectList(_context.Mascotas, "MascotaId", "MascotaId", adopcione.MascotaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", adopcione.UsuarioId);
            return View(adopcione);
        }

        // GET: Adopciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopcione = await _context.Adopciones
                .Include(a => a.Mascota)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AdopcionId == id);
            if (adopcione == null)
            {
                return NotFound();
            }

            return View(adopcione);
        }

        // POST: Adopciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopcione = await _context.Adopciones.FindAsync(id);
            if (adopcione != null)
            {
                _context.Adopciones.Remove(adopcione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopcioneExists(int id)
        {
            return _context.Adopciones.Any(e => e.AdopcionId == id);
        }
    }
}
