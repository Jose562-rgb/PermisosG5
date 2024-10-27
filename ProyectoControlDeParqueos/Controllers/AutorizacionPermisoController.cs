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
    public class AutorizacionPermisoController : Controller
    {
        private readonly LoginDbContext _context;

        public AutorizacionPermisoController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: AutorizacionPermiso
        public async Task<IActionResult> Index()
        {
            return View(await _context.AutorizacionPermiso.ToListAsync());
        }

        // GET: AutorizacionPermiso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorizacionPermiso = await _context.AutorizacionPermiso
                .FirstOrDefaultAsync(m => m.IdAutorizacion == id);
            if (autorizacionPermiso == null)
            {
                return NotFound();
            }

            return View(autorizacionPermiso);
        }

        // GET: AutorizacionPermiso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AutorizacionPermiso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAutorizacion,IdPermiso,IdEmpleadoAutorizador,FechaAutorizacion,Estado,Comentarios")] AutorizacionPermiso autorizacionPermiso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autorizacionPermiso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autorizacionPermiso);
        }

        // GET: AutorizacionPermiso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorizacionPermiso = await _context.AutorizacionPermiso.FindAsync(id);
            if (autorizacionPermiso == null)
            {
                return NotFound();
            }
            return View(autorizacionPermiso);
        }

        // POST: AutorizacionPermiso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAutorizacion,IdPermiso,IdEmpleadoAutorizador,FechaAutorizacion,Estado,Comentarios")] AutorizacionPermiso autorizacionPermiso)
        {
            if (id != autorizacionPermiso.IdAutorizacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autorizacionPermiso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorizacionPermisoExists(autorizacionPermiso.IdAutorizacion))
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
            return View(autorizacionPermiso);
        }

        // GET: AutorizacionPermiso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autorizacionPermiso = await _context.AutorizacionPermiso
                .FirstOrDefaultAsync(m => m.IdAutorizacion == id);
            if (autorizacionPermiso == null)
            {
                return NotFound();
            }

            return View(autorizacionPermiso);
        }

        // POST: AutorizacionPermiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autorizacionPermiso = await _context.AutorizacionPermiso.FindAsync(id);
            if (autorizacionPermiso != null)
            {
                _context.AutorizacionPermiso.Remove(autorizacionPermiso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorizacionPermisoExists(int id)
        {
            return _context.AutorizacionPermiso.Any(e => e.IdAutorizacion == id);
        }
    }
}
