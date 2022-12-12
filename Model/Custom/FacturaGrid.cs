using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class FacturaGrid
    {

        [Display(Name = "Numero de Factura")]
        public int Id_Factura { get; set; }
        [Display(Name = "DNI del Cliente")]
        public int Id_Cliente { get; set; }
        [Display(Name = "Apellido y nombre del Cliente")]
        public string ApyNom { get; set; }
        [Display(Name = "Fecha de Vencimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaVencimiento { get; set; }
        [Display(Name = "Fecha de Emision")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaEmision { get; set; }
        public double Total { get; set; }
        public string CondicionTributaria { get; set; }
    }
}