using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class FacturaGrid
    {
        public int Id_Factura { get; set; }
        [Display(Name = "Id del Cliente")]
        public int Id_Cliente { get; set; }
        [Display(Name = "Apellido y nombre del Cliente")]
        public string ApyNom { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaEmision { get; set; }
        public double Total { get; set; }
    }
}