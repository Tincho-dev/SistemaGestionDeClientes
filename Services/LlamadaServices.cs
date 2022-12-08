using Model.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistanse
{
    public class LlamadaServices
    {
        private readonly ApplicationDbContext ctx = new ApplicationDbContext();
        public IEnumerable<Llamada> GetAll()
        {
            var result = new List<Llamada>();

            using (ctx)
            {
                result = ctx.Llamadas.OrderBy(x => x.Fecha).ToList();
            }

            return result;
        }

        public Llamada Get(int id)
        {
            var result = new Llamada();

            using (ctx)
            {
                result = ctx.Llamadas.Where(x => x.Id_Llamada == id).Single();
            }

            return result;
        }

        public void Create(Llamada llamada)
        {
            using (ctx)
            {
                var Llamada = new Llamada();

                Llamada.Cliente_CUIT = llamada.Cliente_CUIT;
                Llamada.Fecha = llamada.Fecha;
                Llamada.Id_Llamada = llamada.Id_Llamada;

                ctx.Llamadas.Add(Llamada);
                ctx.SaveChanges();
            }
        }

        public void update(Llamada llamada)
        {
            using (ctx)
            {
                var originalEntity = ctx.Llamadas.Where(x => x.Id_Llamada
                == llamada.Id_Llamada
                ).Single();

                originalEntity.Cliente_CUIT = llamada.Cliente_CUIT;
                originalEntity.Fecha = llamada.Fecha;
                originalEntity.Id_Llamada = llamada.Id_Llamada;


                ctx.Entry(originalEntity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public void delete(int id)
        {
            try
            {
                using (ctx)
                {
                    Llamada llamada = ctx.Llamadas.Where(x => x.Id_Llamada == id).Single();

                    ctx.Llamadas.Remove(llamada);

                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
     }
}
