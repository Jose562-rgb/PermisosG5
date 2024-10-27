using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDeParqueos.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre del Empleado")]
        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Cargo")]
        public string Cargo { get; set; }

        [Display(Name = "Fecha de Ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }
    }
}
