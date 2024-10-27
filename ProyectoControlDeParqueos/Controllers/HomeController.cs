using Microsoft.AspNetCore.Mvc;
using ProyectoControlDeParqueos.Models;
using System.Diagnostics;
using System.Linq;

namespace ProyectoControlDeParqueos.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoginDbContext _context;

        public HomeController(LoginDbContext context)
        {
            _context = context;
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Index()
        {
            // Obtener datos para el gráfico
            var totalPermisos = _context.PermisoLaboral.Count();
            var permisosAprobados = _context.PermisoLaboral.Count(p => p.Estado == "Aprobado");
            var permisosRechazados = _context.PermisoLaboral.Count(p => p.Estado == "Rechazado");
            var permisosPendientes = _context.PermisoLaboral.Count(p => p.Estado == "Pendiente");

            // Asignar datos al ViewBag
            ViewBag.TotalPermisos = totalPermisos;
            ViewBag.PermisosAprobados = permisosAprobados;
            ViewBag.PermisosRechazados = permisosRechazados;
            ViewBag.PermisosPendientes = permisosPendientes;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
