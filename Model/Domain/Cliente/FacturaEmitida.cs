using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class FacturaEmitida
    {
        [Key]
        public int Id_FacturaEmitida { get; set; }
        [Display(Name = "Numero de Factura")]
        public int Id_Factura { get; set; }
        [ForeignKey("Id_Factura")]
        public virtual Factura Factura{ get; set; }

        public double Total { get; set; }

        [Required(ErrorMessage = "Fecha de Emision necesaria:")]
        [Display(Name = "Fecha de Emision: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEmision { get; set; }
        [Required(ErrorMessage = "Fecha de Vencimiento necesaria:")]
        [Display(Name = "Fecha de Vencimiento: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaVencimiento { get; set; }

        [Display(Name = "Cliente: ")]
        public int Id_Cliente { get; set; }
        [Display(Name = "DNI del Cliente")]
        public int DNI { get; set; }
        [Display(Name = "Apellido y nombre del Cliente")]
        public string ApyNom { get; set; }
        [Display(Name = "Condicion Tributaria del Cliente")]
        public string CondicionTributaria { get; set; }

        [Display(Name = "Legajo Empleado:")]
        public int LegajoEmpleado { get; set; }
        [Display(Name = "Apellido y nombre del Empleado:")]
        public string ApyNomEmp { get; set; }

        public virtual ICollection<DetalleEmitido> DetallesFactura { get; set; }
    }
}
