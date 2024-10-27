using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoControlDeParqueos.Models
{
    public class Cargos
    {
        [Key] //Anotaciones

        [Display(Name = "Nombre del cargo")]
        public string? nombre { get; set; }

        [DisplayName("persona")]
        [ForeignKey("idPersona")]
        public int idPersona { get; set; }
        public virtual persona? persona { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }



    }
}
