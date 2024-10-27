using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class Auditoria
    {
        [Key]
        public int IdAuditoria { get; set; }

        [Display(Name = "Acción Realizada")]
        public string Accion { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Fecha de la Acción")]
        [DataType(DataType.DateTime)]
        public DateTime FechaAccion { get; set; }
    }
}
