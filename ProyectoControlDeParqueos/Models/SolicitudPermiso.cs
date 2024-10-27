using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoControlDePermisos.Models
{
    public enum TipoPermiso
    {
        PermisoMedico,
        PermisoVacacional,
        PermisoPersonal
    }

    public class SolicitudPermiso
    {
        [Key]
        public int IdPermiso { get; set; }

        [Display(Name = "Tipo de Permiso")]
        [Required]
        public TipoPermiso TipoPermiso { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Motivo del Permiso")]
        [Required]
        [StringLength(500)]
        public string Motivo { get; set; }

        [Display(Name = "Empleado")]
        [Required]
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        [Display(Name = "Estatus")]
        [Required]
        public string Estatus { get; set; } = "Pendiente"; // Siempre será "Pendiente" en la solicitud.
    }
}
