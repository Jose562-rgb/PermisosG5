

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoControlDePermisos.Models;

namespace ProyectoControlDeParqueos.Models
{
    public class LoginDbContext : IdentityDbContext<ApplicationUsers>

    {

        public LoginDbContext (DbContextOptions<LoginDbContext> options) : base (options) 
        
        { 
        }

        
        public DbSet<Cargos> cargos { get; set; }


        public DbSet<persona>personas { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Permiso> Permiso { get; set; }

        public DbSet<Rol> Rol { get; set; }

        public DbSet<Auditoria> Auditoria { get; set; }
        public DbSet<ProyectoControlDePermisos.Models.Empleados> Empleados { get; set; } = default!;
        public DbSet<ProyectoControlDePermisos.Models.PermisoLaboral> PermisoLaboral { get; set; } = default!;
        public DbSet<ProyectoControlDePermisos.Models.PermisoMedico> PermisoMedico { get; set; } = default!;
        public DbSet<ProyectoControlDePermisos.Models.PermisoVacacional> PermisoVacacional { get; set; } = default!;
        public DbSet<PermisoPersonal> PermisoPersonal { get; set; } = default!;
        public DbSet<ProyectoControlDePermisos.Models.AutorizacionPermiso> AutorizacionPermiso { get; set; } = default!;

    }
}
