using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class ReportePorLlamadasGrid
    {
        [Display(Name = "Nombre y Apellido")]
        public string ApyNom { get; set; }
        public int TotalLlamadas { get; set; }
        public int DNI { get; set; }

    }
}
