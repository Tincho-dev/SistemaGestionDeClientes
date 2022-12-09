using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Domain
{
    public class Reporte
    {
        [Key]
        public int Id_cliente { get; set; }
        public string NombreCliente { get; set; }
        public int Cantidad de llamadas { get; set; }
        public string NombreCliente { get; set; }
    }
}