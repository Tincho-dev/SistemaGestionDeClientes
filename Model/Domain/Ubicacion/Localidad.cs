using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Localidad
    {
        [Key]
        public int Cod_Postal { get; set; }
        public string Nombre { get; set; }
        public int Id_Provincia { get; set; }
        [ForeignKey("Id_Provincia")]
        public virtual Provincia Provincia { get; set; }
    }
}