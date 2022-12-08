using System.ComponentModel.DataAnnotations;

namespace Model.Domain
{
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }
        public string nombre { get; set; }

    }
}