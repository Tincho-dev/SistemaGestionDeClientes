using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class DetalleEmitido
    {
        [Key]
        public int Id_DetalleEmitido { get; set; }
        public int Id_Detalle { get; set; }
        [ForeignKey("Id_Detalle")]
        public virtual Detalle Detalle { get; set; }
        [Display(Name = "Precio Unitario: ")]
        public double PrecioUnitario { get; set; }
        [Display(Name = "Cantidad: ")]
        public int Cantidad { get; set; }
        [Display(Name = "Descripción: ")]
        public string Descripcion { get; set; }
        [Display(Name = "Sub total")]
        public double SubTotal { get; set; }

        [Display(Name = "ID Proyecto: ")]
        public int Id_Proyecto { get; set; }
        [Display(Name = "Titulo Proyecto")]
        public string Titulo { get; set; }

        [Display(Name = "ID Factura: ")]
        public int Id_Factura { get; set; }
        [ForeignKey("Id_Factura")]
        public virtual FacturaEmitida Factura { get; set; }

    }
}