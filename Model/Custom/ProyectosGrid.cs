﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Custom
{
    public class ProyectosGrid
    {
        public int Id_Proyecto { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechInicio { get; set; }
        [Display(Name = "Fecha estimada de Fin")]
        public DateTime FechFin { get; set; }
        [Display(Name = "Costo Total")]
        public double Costo { get; set; }
        [Display(Name = "DNI Cliente")]
        public int ClienteDNI { get; set; }
    }
}
