using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class EmpleadoGrid
    {
        public int Legajo { get; set; }
        public int DNI { get; set; }
        [Display(Name = "Nombre Completo")]
        public string ApyNom { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
        public string Rol { get; set; }
    }
}
