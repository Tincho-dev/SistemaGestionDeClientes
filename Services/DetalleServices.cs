using Model.Custom;
using Persistanse;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class DetalleServices
    {
        private readonly DetalleServices userService = new DetalleServices();

        public IEnumerable<DetalleGrid> GetAll()
        {
            var result = new List<DetalleGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from det in db.Detalles
                        select new DetalleGrid
                        {
                            PrecioU = det.PrecioUnitario,
                            SubTotal = det.SubTotal,
                            Cantidad = det.Cantidad
                        }
                    ).ToList();
            }

            return result;
        }
    }
}