using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public int DNI { get; set; }
        public int Telefono { get; set; }
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
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

    }
}