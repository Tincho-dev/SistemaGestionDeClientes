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
        [Display(Name = "DNI: ")]
        public int DNI { get; set; }
        [Display(Name = "Telefono: ")]
        public long Telefono { get; set; }
        [MaxLength(150)]
        [Display(Name = "Email: ")]
        public string Mail { get; set; }
        [MaxLength(150)]
        [Display(Name = "Condición Tributaria: ")]
        public string Condicion_Tributaria { get; set; }
        [MaxLength(150)]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [MaxLength(150)]
        [Display(Name = "Apellido: ")]
        public string Apellido { get; set; }
        //public int Id_Domicilio { get; set; }
        //[ForeignKey("Id_Domicilio")]
        //public virtual Domicilio Domicilio { get; set; }
        [Required(ErrorMessage = "Debe Ingresar la Fecha de Ingreso")]
        [Display(Name = "Fecha de Nacimiento: ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Factura> Facturas { get; set; }
    }
}