using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDeParqueos.Models
{
    public class persona


    {

        [Key] //Anotacion
        public int idPersona { get; set; }

        [Display(Name ="Nombre de persona")]
        public string nombre { get; set; }

        [Display(Name ="Estatura de persona") ]
        [Precision(18,2)]
        public decimal estatura { get; set; }

        [Display(Name= "Estado")]
        public bool estado { get; set; }

    }
}
