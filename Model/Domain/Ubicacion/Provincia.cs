using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Provincia
    {
        [Key]
        public int Id_Provincia { get; set; } // En la BD esta como `idpPovincia
        public string Nombre { get; set; }
        public int Id_Pais { get; set; }
        [ForeignKey("Id_Pais")]
        public virtual Pais Pais { get; set; }
    }
}