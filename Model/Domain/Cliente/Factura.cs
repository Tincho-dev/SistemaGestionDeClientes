using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Factura
    {
        [Key]
        public int Id_Factura { get; set; }
        public double Total { get; set; }
        public string RutaCopiaOriginal { get; set; }
        [Required(ErrorMessage = "Fecha de Emision necesaria:")]
        [Display(Name = "Fecha de Emision")]
        [DataType(DataType.Date)]
        public DateTime FechaEmision { get; set; }
        [Required(ErrorMessage = "Fecha de Vencimiento necesaria:")]
        [Display(Name = "Fecha de Vencimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; set; }
        public int Id_Historial { get; set; }
        [ForeignKey("Id_Historial")]
        public virtual Historial Historial { get; set; }
        public int LegajoEmpleado { get; set; }
        [ForeignKey("LegajoEmpleado")]
        [Display(Name = "Legajo del Empleado")]
        public virtual Empleado Empleado { get; set; }

    }
}
