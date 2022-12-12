using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class LlamadaGrid
    {
        [Display(Name = "id llamada")]
        public int Id { get; set; }
        [Display(Name = "DNI")]
        public int DNI { get; set; }
        public int Id_Cliente { get; set; }
        [Display(Name = "Nombre y Apellido del Cliente")]
        public string ApyNom { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha{ get; set; }
    }
}