﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoControlDePermisos.Models
{
    public class PermisoLaboral
    {
        [Key]
        public int IdPermiso { get; set; }

        [Display(Name = "Tipo de Permiso")]
        [Required]
        public string? TipoPermiso { get; set; } // Vacaciones, Suspensión Médica, etc.

        [Display(Name = "Inicio")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Fin")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Motivo")]
        public string? Motivo { get; set; } // Detalles adicionales o justificación.

        [Display(Name = "Empleado")]
        [ForeignKey("IdEmpleado")]
        public int IdEmpleado { get; set; } // Relación con el empleado que solicita el permiso.
       // public virtual Empleados? Empleados { get; set; }

        [Display(Name = "Estado")]
        public string? Estado { get; set; }

        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }


    }
}