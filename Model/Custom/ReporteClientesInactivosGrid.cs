using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class ReporteClientesInactivosGrid
    {
        [Display(Name = "Nombre y Apellido")]
        public string ApyNom { get; set; }
        [Display(Name = "Fecha de Ultima Factura")]
        public DateTime UltimaFactura{ get; set; }
        [Display(Name = "Fecha de Ultima Llamada")]
        public DateTime UltimaLlamada{ get; set; }
        public int Id_Cliente { get; set; }
    }
}
