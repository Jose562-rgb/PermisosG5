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
    public class PermisoMedicoController : Controller
    {
        private readonly LoginDbContext _context;

        public PermisoMedicoController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: PermisoMedico
        public async Task<IActionResult> Index()
        {
            return View(await _context.PermisoMedico.ToListAsync());
        }

        // GET: PermisoMedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoMedico = await _context.PermisoMedico
                .FirstOrDefaultAsync(m => m.IdPermisoMedico == id);
            if (permisoMedico == null)
            {
                return NotFound();
            }

            return View(permisoMedico);
        }

        // GET: PermisoMedico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermisoMedico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermisoMedico,FechaInicio,FechaFin,Descripcion,IdEmpleado")] PermisoMedico permisoMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisoMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permisoMedico);
        }

        // GET: PermisoMedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoMedico = await _context.PermisoMedico.FindAsync(id);
            if (permisoMedico == null)
            {
                return NotFound();
            }
            return View(permisoMedico);
        }

        // POST: PermisoMedico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermisoMedico,FechaInicio,FechaFin,Descripcion,IdEmpleado")] PermisoMedico permisoMedico)
        {
            if (id != permisoMedico.IdPermisoMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisoMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoMedicoExists(permisoMedico.IdPermisoMedico))
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
            return View(permisoMedico);
        }

        // GET: PermisoMedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoMedico = await _context.PermisoMedico
                .FirstOrDefaultAsync(m => m.IdPermisoMedico == id);
            if (permisoMedico == null)
            {
                return NotFound();
            }

            return View(permisoMedico);
        }

        // POST: PermisoMedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permisoMedico = await _context.PermisoMedico.FindAsync(id);
            if (permisoMedico != null)
            {
                _context.PermisoMedico.Remove(permisoMedico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoMedicoExists(int id)
        {
            return _context.PermisoMedico.Any(e => e.IdPermisoMedico == id);
        }
    }
}
