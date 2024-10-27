using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoControlDeParqueos.Models;
using ProyectoControlDePermisos.Models;

namespace ProyectoControlDeParqueos.Controllers
{
    public class PermisoVacacionalController : Controller
    {
        private readonly LoginDbContext _context;

        public PermisoVacacionalController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: PermisoVacacional
        public async Task<IActionResult> Index()
        {
            return View(await _context.PermisoVacacional.ToListAsync());
        }

        // GET: PermisoVacacional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoVacacional = await _context.PermisoVacacional
                .FirstOrDefaultAsync(m => m.IdPermisoVacacional == id);
            if (permisoVacacional == null)
            {
                return NotFound();
            }

            return View(permisoVacacional);
        }

        // GET: PermisoVacacional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermisoVacacional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermisoVacacional,FechaInicio,FechaFin,Comentario,IdEmpleado")] PermisoVacacional permisoVacacional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisoVacacional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permisoVacacional);
        }

        // GET: PermisoVacacional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoVacacional = await _context.PermisoVacacional.FindAsync(id);
            if (permisoVacacional == null)
            {
                return NotFound();
            }
            return View(permisoVacacional);
        }

        // POST: PermisoVacacional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermisoVacacional,FechaInicio,FechaFin,Comentario,IdEmpleado")] PermisoVacacional permisoVacacional)
        {
            if (id != permisoVacacional.IdPermisoVacacional)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisoVacacional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoVacacionalExists(permisoVacacional.IdPermisoVacacional))
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
            return View(permisoVacacional);
        }

        // GET: PermisoVacacional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoVacacional = await _context.PermisoVacacional
                .FirstOrDefaultAsync(m => m.IdPermisoVacacional == id);
            if (permisoVacacional == null)
            {
                return NotFound();
            }

            return View(permisoVacacional);
        }

        // POST: PermisoVacacional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permisoVacacional = await _context.PermisoVacacional.FindAsync(id);
            if (permisoVacacional != null)
            {
                _context.PermisoVacacional.Remove(permisoVacacional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoVacacionalExists(int id)
        {
            return _context.PermisoVacacional.Any(e => e.IdPermisoVacacional == id);
        }
    }
}
