using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Detalle
    {
        [Key]
        public int Id_Detalle { get; set; }
        [Display(Name = "ID Proyecto: ")]
        public int Id_Proyecto { get; set; }
        [ForeignKey("Id_Proyecto")]
        public virtual Proyectos Proyectos { get; set; }
        [Display(Name = "ID Factura: ")]
        public int Id_Factura { get; set; }
        [ForeignKey("Id_Factura")]
        public virtual Factura Factura { get; set; }
        [Display(Name = "Precio Unitario: ")]
        public double PrecioUnitario { get; set; }
        [Display(Name = "Cantidad: ")]
        public int Cantidad { get; set; }
        [Display(Name = "Descripción: ")]
        public string Descripcion { get; set; }
        public double SubTotal { get; set; }

    }
}