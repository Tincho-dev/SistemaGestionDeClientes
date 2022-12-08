using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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