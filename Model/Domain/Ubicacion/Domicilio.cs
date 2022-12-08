using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Domicilio
    {
        [Key]
        public int Id_Domicilio { get; set; }
        public string Calle { get; set; }
        public string Barrio { get; set; }
        public string Altura { get; set; }
        public int Cod_Postal { get; set; }
        [ForeignKey("Cod_Postal")]
        public virtual Localidad Localidad { get; set; }
    }
}