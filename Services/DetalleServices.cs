using Model.Custom;
using Persistanse;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistanse;
using System.Collections;
using System.Data.Entity;

namespace Persistanse
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