using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ReportesServices
    {
        private readonly UserService userService = new UserService();


        public IEnumerable<ReportePorLlamadasGrid> GetReportePorLlamadas()
        {
            var result = new List<ReportePorLlamadasGrid>();
            using (var db = new ApplicationDbContext())
            {
                result = (
                        from clie in db.Clientes
                        from llam in db.Llamadas.Where(x => x.Id_Cliente == clie.Id)
                        select new ReportePorLlamadasGrid
                        {
                            ApyNom = clie.Nombre + " " + clie.Apellido,
                            TotalLlamadas = (from lla in db.Llamadas.Where(x => x.Id_Cliente == clie.Id)
                                             select lla
                                            ).Count(),//contar la cantidad de llamadas del cliente
                            DNI = clie.DNI
                        }
                    ).Distinct().OrderByDescending(x => x.TotalLlamadas).ToList();
            }
            return result;
        }


        public IEnumerable<ReportePorIngresosGrid> GetMayorIngresosGenerados()
        {
            var result = new List<ReportePorIngresosGrid>();

            using (var db = new ApplicationDbContext())
            {

                result = (
                        from clie in db.Clientes
                        from fact in db.Facturas.Where(x => x.Id_Cliente == clie.Id)
                        from detall in db.Detalles.Where(x => x.Id_Factura == fact.Id_Factura)
                        from proyec in db.Proyectos.Where(x => x.Id_Proyecto == detall.Id_Proyecto)
                        select new ReportePorIngresosGrid
                        {
                            
                            ApyNom = clie.Nombre + " " + clie.Apellido,
                            TotalIngresos = (from fact in db.Facturas.Where(x => x.Id_Cliente == clie.Id)
                                             from detall in db.Detalles.Where(x => x.Id_Factura == fact.Id_Factura)
                                             from proy in db.Proyectos.Where(x => x.Id_Proyecto == detall.Id_Proyecto)
                                             select proy.Costo
                                            ).Sum(),
                            DNI = clie.DNI,
                            TotalProyectos =
                            (from proy in db.Proyectos.Where(x => x.Id_Cliente == clie.Id)
                                              select proy
                                            ).Count()
                        }
                    ).Distinct().ToList();
            }

            return result;
        }

        public IEnumerable<ReporteClientesInactivosGrid> GetClientesInactivos()
        {
            var result = new List<ReporteClientesInactivosGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from clie in db.Clientes
                        from llam in db.Llamadas.Where(x => x.Id_Cliente == clie.Id)
                        select new ReporteClientesInactivosGrid
                        {

                        }
                    ).ToList();
            }

            return result;
        }
    }
}
