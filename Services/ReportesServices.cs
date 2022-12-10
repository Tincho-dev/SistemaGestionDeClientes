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
                    ).Distinct().OrderBy(x => x.TotalLlamadas).ToList();
            }

            return result;
        }
        /*
        public IEnumerable<ReporteGrid> GetAll()
        {
            var result = new List<ReporteGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from rep in db.Reporte
                        select new ReporteGrid
                        {
                            Id = rep.Id_cliente,
                            NombreCliente = rep.NombreCliente,
                        }
                    ).OrderBy(x => x.Id).ToList();
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
                        from detall in db.Detalles
                        from fact in db.Facturas.Where(x => x.Id_Factura == detall.Id_Factura)
                        from proyec in db.Proyectos.Where(x => x.Id_Proyecto == detall.Id_Detalle) 
                        select new ReportePorIngresosGrid
                        {
                            ApyNom = clie.Nombre + " " + clie.Apellido,
                            TotalIngresos = (
                                            from clie in db.Clientes
                                            from detall in db.Detalles
                                            from fact in db.Facturas.Where(x => x.Id_Factura == detall.Id_Factura)
                                            from proy in db.Proyectos.Where(x => x.Id_Proyecto == detall.Id_Detalle)
                                            select //agrego una nueva fila para realizar la suma   //SAQUÉ DE GOOGLE NO SÉ SI ESTÁ BIEN 
                                                   DataTable dt = Datos();
                                                   DataRow row = dt.NewRow();
                                                   dt.Rows.Add(row);

                                                   //mostramos los datos en el datagridview
                                                   dataGridView1.AutoGenerateColumns = false;
                                                   dataGridView1.DataSource = dt;

                                                   //Mostramos el valor de 0 en la fila que agregamos
                                                   DataGridViewRow rowtotal = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                                                   rowtotal.Cells["Total"].Value = 0;
                                                        ).Sum(x => x.Total),
                            ClienteDNI = clie.DNI //cambiar aqui
                        }
                    ).OrderBy(x => x.TotalIngresos).ToList();
            }

            return result;
        }
        
         */
        
        public IEnumerable<ReporteClientesInactivosGrid> GetClientesInactivos()
        {
            var result = new List<ReporteClientesInactivosGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from clie in db.Clientes
                        from llam in db.Llamadas.Where(x=> x.Id_Cliente == clie.Id)
                        select new ReporteClientesInactivosGrid
                        {

                        }
                    ).ToList();
            }

            return result;
        }
 
        
        /*
        public ReporteGrid Get(int id)
        {
            var result = new ReporteGrid();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from rep in db.Reportes.Where(x => x.id == id)
                        select new ReporteGrid
                        {
                            id = rep.id,
                            ApyNom = rep.NombreCliente,
                        }
                    ).Single();
            }

            return result;
        }
        
        public Reporte GetEdit(int id)
        {
            var result = new Reporte();

            using (var db = new ApplicationDbContext())
            {
                result = db.Reportes.Where(x => x.id == id).Single();
            }
            return result;
        }

 */
    }
}
