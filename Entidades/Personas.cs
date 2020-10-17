using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace RegistroDetalle.Entidades
{
     public class Personas{
        [Key]
        public int PersonaID { get; set; }
        public string Nombres { get; set; }
        public decimal Balance { get; set; }
    }

}