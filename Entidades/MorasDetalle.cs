using System;
using  System.ComponentModel.DataAnnotations;

namespace Detalle_Registro.Entidades{
    public class MorasDetalle{
        [Key]
        public int Id { get; set; }
        public int MoraId { get; set; }
        public int PrestamoId { get; set; }
        public decimal Valor { get; set; }

        public MorasDetalle()
        {
            Id = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }

        public MorasDetalle(int moraId, int prestamoId, decimal valor)
        {
            Id = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }

    }

    
}