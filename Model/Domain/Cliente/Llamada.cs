using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Llamada
    {
        [Key]
        public int Id_Llamada { get; set; }
        public DateTime Fecha { get; set; }
        public int Cliente_CUIT { get; set; }
        [ForeignKey("Cliente_CUIT")]
        public virtual Cliente Cliente { get; set; }

    }
}