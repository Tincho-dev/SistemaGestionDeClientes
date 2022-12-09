using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class ReporteGrid
    {
        [Display(Name = "id cliente")]
        public int Id { get; set; }
        [Display(Name = "nombre cliente")]
        public string NombreCliente { get; set; }
    }
}