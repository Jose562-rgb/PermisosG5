using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class Permiso
    {
        [Key]
        public int IdPermiso { get; set; }

        [Display(Name = "Descripción del Permiso")]
        [Required]
        public string Descripcion { get; set; }

        [Display(Name = "Nivel de Acceso")]
        [Range(1, 10)]
        public int NivelAcceso { get; set; }

        [Display(Name = "Vigente")]
        public bool Vigente { get; set; }
    }
}
