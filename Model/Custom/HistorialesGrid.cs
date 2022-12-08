using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Custom
{
    public class HistorialesGrid //historial de facturas
    {
        [Display(Name = "id")]
        public int id { get; set; }
        [Display(Name = "Sueldo adeudado")]
        public Double SueldoAdeudado { get; set; }
    }
}