using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model.Domain
{
    public class Historial
    {
        [Key]
        public int Id_Historial { get; set; }
        public double SaldoAdeudado { get; set; }
        public int Cliente_DNI { get; set; }
        [ForeignKey("Cliente_DNI")]
        public virtual Cliente Cliente { get; set; } 
    }
}