using Microsoft.AspNetCore.Mvc;
using SistemaWebEmpleados.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaWebEmpleados.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Apellido { get; set; }
        [Required]
        [RegularExpression(@"^(\d{7}|\d{8})$", ErrorMessage = "Ingrese un numero de DNI válido")]
        public int DNI { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        [RegularExpression(@"^[A]{2}[0-9]{5}", ErrorMessage = "El legajo debe contener dos letras A y 5 numeros... Ej: AA00000")]        
        public string Legajo { get; set; } = null!;

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Fecha de Nacimiento")]
        [FechaNacimientoAtributte]
        public DateTime FechaNacimiento { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string Titulo { get; set; }
    }
}
