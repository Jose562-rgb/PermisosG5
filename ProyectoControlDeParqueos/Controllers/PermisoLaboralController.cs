using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoControlDeParqueos.Models;
using ProyectoControlDePermisos.Models;

namespace ProyectoControlDeParqueos.Controllers
{
    [Authorize]
    public class PermisoLaboralController : Controller
    {
        private readonly LoginDbContext _context;

        public PermisoLaboralController(LoginDbContext context)
        {
            _context = context;
        }

        // GET: PermisoLaboral
        public async Task<IActionResult> Index()
        {
            var datos = await _context.PermisoLaboral.ToListAsync();
            var modelo = new List<PermisoLaboralVista>();
            foreach (var registro in datos)
            {
                modelo.Add(new PermisoLaboralVista
                {
                    IdPermiso = registro.IdPermiso,
                    TipoPermiso = registro.TipoPermiso,
                    FechaInicio = registro.FechaInicio,
                    FechaFin = registro.FechaFin,
                    IdEmpleado = _context.Empleados.FirstOrDefault(c => c.IdEmpleado.Equals(registro.IdEmpleado)).NombreCompleto,
                    Estado = registro.Estado
                });
            }

            return View(modelo);
        }

        // GET: PermisoLaboral/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            var TipoPermiso = new List<SelectListItem>
            {
                new SelectListItem { Value = "Emergencia", Text = "Emergencia" },
                new SelectListItem { Value = "Vacaciones", Text = "Vacaciones" },
                new SelectListItem { Value = "Enfermedad", Text = "Enfermedad" },
                new SelectListItem { Value = "Cumpleaños", Text = "Cumpleaños" },
                new SelectListItem { Value = "Maternidad/Paternidad", Text = "Maternidad/Paternidad" }
            };

            ViewBag.TipoPermiso = TipoPermiso;

            // Filtrar empleados activos (EstadoActivo == true)
            var Empleados = new SelectList(_context.Empleados
                .Where(e => e.EstadoActivo) // Solo empleados con EstadoActivo en true
                .ToList(), "IdEmpleado", "NombreCompleto");

            ViewBag.Empleados = Empleados;

            return View();
        }

        // POST: PermisoLaboral/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermiso,TipoPermiso,FechaInicio,FechaFin,Motivo,IdEmpleado")] PermisoLaboral permisoLaboral)
        {
            if (ModelState.IsValid)
            {
                permisoLaboral.Estado = "Pendiente";
                _context.Add(permisoLaboral);
                await _context.SaveChangesAsync();

                return RedirectToAction("PermisoSolicitado");
            }

            return View(permisoLaboral);
        }

        // GET: PermisoLaboral/PermisoSolicitado
        [AllowAnonymous]
        public IActionResult PermisoSolicitado()
        {
            return View();
        }

        // GET: PermisoLaboral/Historico
        public async Task<IActionResult> Historico()
        {
            var datos = await _context.PermisoLaboral.ToListAsync();
            var modelo = new List<PermisoLaboralVista>();
            foreach (var registro in datos)
            {
                modelo.Add(new PermisoLaboralVista
                {
                    IdPermiso = registro.IdPermiso,
                    TipoPermiso = registro.TipoPermiso,
                    FechaInicio = registro.FechaInicio,
                    FechaFin = registro.FechaFin,
                    IdEmpleado = _context.Empleados.FirstOrDefault(c => c.IdEmpleado.Equals(registro.IdEmpleado)).NombreCompleto,
                    Estado = registro.Estado,
                    Observaciones = registro.Observaciones
                });
            }

            return View(modelo); 
        }

        // GET: PermisoLaboral/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoLaboral = await _context.PermisoLaboral.FindAsync(id);
            if (permisoLaboral == null)
            {
                return NotFound();
            }

            var Estados = new List<SelectListItem>
            {
                new SelectListItem { Value = "Pendiente", Text = "Pendiente" },
                new SelectListItem { Value = "Aprobado", Text = "Aprobado" },
                new SelectListItem { Value = "Rechazado", Text = "Rechazado" }
            };

            ViewBag.Estados = Estados;

            // Filtrar empleados activos para la edición (EstadoActivo == true)
            var Empleados = new SelectList(_context.Empleados
                .Where(e => e.EstadoActivo) // Solo empleados activos
                .ToList(), "IdEmpleado", "NombreCompleto", permisoLaboral.IdEmpleado);

            ViewBag.Empleados = Empleados;

            return View(permisoLaboral);
        }
        // POST: PermisoLaboral/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermiso,TipoPermiso,FechaInicio,FechaFin,Motivo,IdEmpleado,Estado,Observaciones")] PermisoLaboral permisoLaboral)
        {
            if (id != permisoLaboral.IdPermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisoLaboral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoLaboralExists(permisoLaboral.IdPermiso))
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

            return View(permisoLaboral);
        }


        // GET: PermisoLaboral/Consultar
        [AllowAnonymous]
        public IActionResult Consultar()
        {
            return View();
        }

        // POST: PermisoLaboral/Consultar
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Consultar(string dpi, string estadoFiltro)
        {
            if (string.IsNullOrEmpty(dpi))
            {
                ModelState.AddModelError(string.Empty, "Por favor, ingrese un DPI válido.");
                return View();
            }

            var solicitudesQuery = from e in _context.Empleados
                                   join p in _context.PermisoLaboral on e.IdEmpleado equals p.IdEmpleado
                                   where e.DPI == dpi // Filtrar por DPI
                                   select new
                                   {
                                       IdPermiso = p.IdPermiso,
                                       TipoPermiso = p.TipoPermiso,
                                       FechaInicio = p.FechaInicio,
                                       FechaFin = p.FechaFin,
                                       Motivo = p.Motivo,
                                       Estado = p.Estado,
                                       NombreCompleto = e.NombreCompleto,
                                       Observaciones = p.Observaciones
                                   };

            // Aplicar filtro por estado si se proporciona
            if (!string.IsNullOrEmpty(estadoFiltro))
            {
                solicitudesQuery = solicitudesQuery.Where(s => s.Estado == estadoFiltro);
            }

            var solicitudes = solicitudesQuery.ToList();

            return View(solicitudes);
        }

        // GET: PermisoLaboral/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoLaboral = await _context.PermisoLaboral
                .FirstOrDefaultAsync(m => m.IdPermiso == id);

            if (permisoLaboral == null)
            {
                return NotFound();
            }

            // Cargar la lista de empleados
            var empleados = new SelectList(_context.Empleados, "IdEmpleado", "NombreCompleto");
            ViewBag.Empleados = empleados;

            return View(permisoLaboral);
        }


        // GET: PermisoLaboral/PDF
        [AllowAnonymous]
        public async Task<IActionResult> PDF(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoLaboral = await _context.PermisoLaboral
                .FirstOrDefaultAsync(c => c.IdPermiso.Equals(id));

            if (permisoLaboral == null)
            {
                return NotFound();
            }

            // Cargar la lista de empleados
            var empleados = new SelectList(_context.Empleados, "IdEmpleado", "NombreCompleto");
            ViewBag.Empleados = empleados;

            return View(permisoLaboral);
        }

        // GET: PermisoLaboral/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoLaboral = await _context.PermisoLaboral
                .FirstOrDefaultAsync(m => m.IdPermiso == id);
            if (permisoLaboral == null)
            {
                return NotFound();
            }

            // Cargar la lista de empleados
            var empleadosList = new SelectList(_context.Empleados, "IdEmpleado", "NombreCompleto");
            ViewBag.Empleados = empleadosList;

            return View(permisoLaboral);
        }


        // POST: PermisoLaboral/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permisoLaboral = await _context.PermisoLaboral.FindAsync(id);
            if (permisoLaboral != null)
            {
                _context.PermisoLaboral.Remove(permisoLaboral);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoLaboralExists(int id)
        {
            return _context.PermisoLaboral.Any(e => e.IdPermiso == id);
        }


    }
}
