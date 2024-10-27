using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class PermisoVacacional
    {
        [Key]
        public int IdPermisoVacacional { get; set; }

        [Display(Name = "Fecha de Inicio de Vacaciones")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin de Vacaciones")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Comentario del Empleado (Opcional)")]
        public string Comentario { get; set; } // Justificación o detalles adicionales.

        [Display(Name = "Empleado")]
        [Required]
        public int IdEmpleado { get; set; } // Relación con el empleado.
    }
}
