using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class AutorizacionPermiso
    {
        [Key]
        public int IdAutorizacion { get; set; }

        [Display(Name = "ID del Permiso")]
        [Required]
        public int IdPermiso { get; set; } // Relación con el permiso que se está autorizando.

        [Display(Name = "Empleado que Autoriza")]
        [Required]
        public int IdEmpleadoAutorizador { get; set; } // Empleado que autoriza o rechaza el permiso.

        [Display(Name = "Fecha de Autorización")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaAutorizacion { get; set; }

        [Display(Name = "Estado del Permiso")]
        [Required]
        public EstadoPermiso Estado { get; set; } // Autorizado, Rechazado, Pendiente.

        [Display(Name = "Comentarios (Opcional)")]
        public string Comentarios { get; set; } // Motivos o comentarios adicionales sobre la autorización.
    }

    // Enum para los estados del permiso
    public enum EstadoPermiso
    {
        Pendiente,
        Autorizado,
        Rechazado
    }
}
