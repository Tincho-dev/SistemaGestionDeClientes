using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public int DNI { get; set; }
        public long Telefono { get; set; }
        [MaxLength(150)]
        public string Mail { get; set; }
        [MaxLength(150)]
        public string Condicion_Tributaria { get; set; }
        [MaxLength(150)]
        public string Nombre { get; set; }
        [MaxLength(150)]
        public string Apellido { get; set; }
        //public int Id_Domicilio { get; set; }
        //[ForeignKey("Id_Domicilio")]
        //public virtual Domicilio Domicilio { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la Fecha de Ingreso")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Factura> Facturas { get; set; }
    }
}