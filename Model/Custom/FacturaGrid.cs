using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class FacturaGrid
    {
        public int Id_Factura { get; set; }
        [Display(Name = "Id del Cliente")]
        public int Id_Cliente { get; set; }
        [Display(Name = "Nombre del Proyecto")]
        public string NombreProyecto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaEmision { get; set; }
        public double Total { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }
    }
}