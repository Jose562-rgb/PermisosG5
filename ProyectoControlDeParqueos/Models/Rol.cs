using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }

        [Display(Name = "Nombre del Rol")]
        [Required]
        public string NombreRol { get; set; }

        [Display(Name = "Descripción del Rol")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha de Creación")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
    }
}
