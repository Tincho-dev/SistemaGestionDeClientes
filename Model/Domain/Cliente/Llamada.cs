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
        [Display(Name = "Fecha de la Llamada: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Display(Name = "ID Cliente: ")]
        public int Id_Cliente { get; set; }
        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }

    }
}