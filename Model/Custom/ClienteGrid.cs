using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Custom
{
    public class ClienteGrid
    {
        [Display(Name = "DNI")]
        public int DNI { get; set; }
        [Display(Name = "Nombre Completo")]
        public string ApyNom { get; set; }
        [Display(Name = "Ingrese Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Email")]
        public string Mail { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}