using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace RegistroDetalle.Entidades
{
 public class Prestamo{
        [Key]
        public int PrestamoID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int PersonaID { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public decimal Balance { get; set; }
    }
}