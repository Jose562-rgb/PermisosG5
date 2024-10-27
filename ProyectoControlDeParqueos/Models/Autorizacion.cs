using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoControlDePermisos.Models
{
    public class Autorizacion
    {
        [Key]
        public int IdAutorizacion { get; set; }

        [Display(Name = "Permiso Solicitado")]
        [Required]
        [ForeignKey("SolicitudPermiso")]
        public int IdPermiso { get; set; }
        public SolicitudPermiso SolicitudPermiso { get; set; }

        [Display(Name = "Estatus")]
        [Required]
        public string Estatus { get; set; } // Se seleccionará "Autorizado" o "Denegado".
    }
}
