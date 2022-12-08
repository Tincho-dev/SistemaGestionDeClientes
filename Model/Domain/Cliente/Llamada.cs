using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Llamada
    {
        [Key]
        public int Id_Llamada { get; set; }
        [Required(ErrorMessage = "Fecha de Llamada necesaria:")]
        [Display(Name = "Fecha de la Llamada")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public int Cliente_CUIT { get; set; }
        [ForeignKey("Cliente_CUIT")]
        public virtual Cliente Cliente { get; set; }

    }
}