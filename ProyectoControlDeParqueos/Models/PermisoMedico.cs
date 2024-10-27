using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class PermisoMedico
    {
        [Key]
        public int IdPermisoMedico { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Descripción de la Condición Médica")]
        public string Descripcion { get; set; }

        [Display(Name = "Empleado")]
        [Required]
        public int IdEmpleado { get; set; } // Relación con el empleado que solicita el permiso médico.
    }
}
