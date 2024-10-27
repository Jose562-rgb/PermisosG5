using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDeParqueos.Models
{
    public class PermisoPersonal
    {
        [Key]
        public int IdPermisoPersonal { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Motivo del Permiso Personal")]
        [Required]
        public string Motivo { get; set; } // Explicación del motivo por el cual se solicita el permiso.

        [Display(Name = "Empleado")]
        [Required]
        public int IdEmpleado { get; set; } // Relación con el empleado que solicita el permiso.
    }
}
