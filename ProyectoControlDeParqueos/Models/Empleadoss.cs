using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Display(Name = "Cargo")]
        [Required]
        public string Cargo { get; set; }

        [Display(Name = "Fecha de Contratación")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Display(Name = "Teléfono (Opcional)")]
        [Phone]
        public string Telefono { get; set; }

        [Display(Name = "Estado Activo")]
        public bool EstadoActivo { get; set; } = true;
    }
}
