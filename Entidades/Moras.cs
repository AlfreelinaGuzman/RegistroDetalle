using System;
using System.Collections.Generic;
using  System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDetalle.Entidades{
    public class Moras{
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MorasDetalle {get; set;} 

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            MorasDetalle = new List<MorasDetalle>();
        }
    }
    
        public class MorasDetalle{
        [Key]
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Valor { get; set; }
    }
}