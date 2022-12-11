using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Detalle
    {
        [Key]
        public int Id_Detalle { get; set; }

        public int Id_Proyecto { get; set; }
        [ForeignKey("Id_Proyecto")]
        public virtual Proyectos Proyectos { get; set; }

        public int Id_Factura { get; set; }
        [ForeignKey("Id_Factura")]
        public virtual Factura Factura { get; set; }

        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double SubTotal { get; set; }

    }
}