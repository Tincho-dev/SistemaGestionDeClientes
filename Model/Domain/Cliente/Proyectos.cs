using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Proyectos
    {
        [Key]
        public int Id_Proyecto { get; set; }

        [Required(ErrorMessage = "Nombre al Proyecto:")]
        [MaxLength(180)]
        public string Titulo { get; set; }
        [Display(Name = "Descripción del Proyecto:")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Fecha de Inicio del Proyecto:")]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "Fecha estimada de Fin del Proyecto:")]
        [Display(Name = "Fecha estimada de Fin")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaFin { get; set; }
        [Display(Name = "Finalizado: ")]
        public bool Finalizado { get; set; }

        [Display(Name = "Id_Cliente")]
        public int Id_Cliente { get; set; }
        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }

        public double Costo { get; set; }
    }
}
