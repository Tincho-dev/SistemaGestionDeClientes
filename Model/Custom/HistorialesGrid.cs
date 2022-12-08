using System;
using System.ComponentModel.DataAnnotations;

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