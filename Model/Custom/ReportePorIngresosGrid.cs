using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class ReportePorIngresosGrid
    {
        [Display(Name = "Nombre y Apellido")]
        public string ApyNom { get; set; }
        [Display(Name = "Total de Proyectos")]
        public int TotalProyectos { get; set; }
        [Display(Name = "DNI del Cliente")]
        public int DNI { get; set; }
        [Display(Name = "Ingresos Generados")]
        public double TotalIngresos { get; set; }
    }
}
