﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProyectoControlDePermisos.Models
{
    public class Empleados
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Display(Name = "Nombre Completo")]
        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Display(Name = "Cargo del Empleado")]
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

        [Display(Name = "Teléfono")]
        [Phone]
        public string Telefono { get; set; }

        [Display(Name = "DPI")]
        [Required]
        public string DPI { get; set; }

        [Display(Name = "Estado del Empleado")]
        [Required]
        public bool EstadoActivo { get; set; } // Si el empleado está activo o no en la empresa.
    }
}