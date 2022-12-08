using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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