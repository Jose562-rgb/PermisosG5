using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoControlDeParqueos.Models;

namespace ProyectoControlDeParqueos.Controllers
{
    public class PermisoPersonalController : Controller
    {
        private readonly LoginDbContext _context;

        public PermisoPersonalController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: PermisoPersonal
        public async Task<IActionResult> Index()
        {
            return View(await _context.PermisoPersonal.ToListAsync());
        }

        // GET: PermisoPersonal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoPersonal = await _context.PermisoPersonal
                .FirstOrDefaultAsync(m => m.IdPermisoPersonal == id);
            if (permisoPersonal == null)
            {
                return NotFound();
            }

            return View(permisoPersonal);
        }

        // GET: PermisoPersonal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermisoPersonal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermisoPersonal,FechaInicio,FechaFin,Motivo,IdEmpleado")] PermisoPersonal permisoPersonal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisoPersonal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permisoPersonal);
        }

        // GET: PermisoPersonal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoPersonal = await _context.PermisoPersonal.FindAsync(id);
            if (permisoPersonal == null)
            {
                return NotFound();
            }
            return View(permisoPersonal);
        }

        // POST: PermisoPersonal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermisoPersonal,FechaInicio,FechaFin,Motivo,IdEmpleado")] PermisoPersonal permisoPersonal)
        {
            if (id != permisoPersonal.IdPermisoPersonal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisoPersonal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoPersonalExists(permisoPersonal.IdPermisoPersonal))
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
            return View(permisoPersonal);
        }

        // GET: PermisoPersonal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoPersonal = await _context.PermisoPersonal
                .FirstOrDefaultAsync(m => m.IdPermisoPersonal == id);
            if (permisoPersonal == null)
            {
                return NotFound();
            }

            return View(permisoPersonal);
        }

        // POST: PermisoPersonal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permisoPersonal = await _context.PermisoPersonal.FindAsync(id);
            if (permisoPersonal != null)
            {
                _context.PermisoPersonal.Remove(permisoPersonal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoPersonalExists(int id)
        {
            return _context.PermisoPersonal.Any(e => e.IdPermisoPersonal == id);
        }
    }
}
