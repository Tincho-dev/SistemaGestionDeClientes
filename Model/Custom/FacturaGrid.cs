using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class FacturaGrid
    {
        public int Id_Factura { get; set; }
        [Display(Name = "DNI del Cliente")]
        public int ClienteDNI { get; set; }
        [Display(Name = "Nombre del Proyecto")]
        public string NombreProyecto { get; set; }
    }
}