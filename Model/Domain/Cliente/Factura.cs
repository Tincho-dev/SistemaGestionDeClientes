using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Factura
    {
        [Key]
        public int Id_Factura { get; set; }
        public double Total { get; set; }

        [Required(ErrorMessage = "Fecha de Emision necesaria:")]
        [Display(Name = "Fecha de Emision")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEmision { get; set; }

        [Required(ErrorMessage = "Fecha de Vencimiento necesaria:")]
        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaVencimiento { get; set; }

        public int Id_Cliente { get; set; }
        [ForeignKey("Id_Cliente")]
        public virtual Cliente Cliente { get; set; }

        public int LegajoEmpleado { get; set; }
        [ForeignKey("LegajoEmpleado")]
        [Display(Name = "Legajo del Empleado")]        
        public virtual Empleado Empleado { get; set; }

        public virtual ICollection<Detalle> DetallesFactura { get; set; }
    }
}
