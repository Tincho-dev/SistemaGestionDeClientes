using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Custom
{
    public class DetalleGrid
    {
        [Display(Name = "id")]
        public int id { get; set; }
        [Display(Name = "Precio Unitario")]
        public Double PrecioU { get; set; }
        [Display(Name = "Sub total")]
        public Double SubTotal { get; set; }
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
    }
}