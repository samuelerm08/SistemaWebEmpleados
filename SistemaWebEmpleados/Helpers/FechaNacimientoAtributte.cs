using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaWebEmpleados.Helpers
{
    public class FechaNacimientoAtributte : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            if (Convert.ToDateTime(value) < new DateTime(1990, 01, 01))
            {
                return new ValidationResult("Solo se aceptan años del 1990 en adelante!");                
            }

            return ValidationResult.Success;
        }
    }
}
