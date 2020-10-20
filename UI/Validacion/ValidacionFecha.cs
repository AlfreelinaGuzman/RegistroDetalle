using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace RegistroDetalle.ValidacionFecha
{
  /*  public class ValidacionFecha : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value != null)
            {
                DateTime fecha = new DateTime();
                DateTime.TryParse(value.ToString(), out fecha);

                if(fecha > DateTime.Now)
                    return new ValidationResult(false,"fecha invalida");
                return ValidationResult.ValidResult;       
             }
            
            return new ValidationResult(false, "Por favor ingrese una fecha");

        }
    }*/
}