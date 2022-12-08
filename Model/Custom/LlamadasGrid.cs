using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class LlamadaGrid
    {
        public int Id { get; set; }
        [Display(Name = "id llamada")]
        public int ClienteDNI { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Fecha{ get; set; }
    }
}