using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class ClienteGrid
    {
        [Display(Name = "Id")]
        public int Id_Cliente { get; set; }
        [Display(Name = "DNI")]
        public int DNI { get; set; }
        [Display(Name = "Nombre Completo")]
        public string ApyNom { get; set; }
        [Display(Name = "Telefono")]
        public long Telefono { get; set; }

        [Display(Name = "Email")]
        public string Mail { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Condicion Tributaria")]
        public string CondicionTributaria { get; set; }
    }
}