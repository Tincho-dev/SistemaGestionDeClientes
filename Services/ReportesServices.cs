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
    class ReportesServices
    {
        private readonly UserService userService = new UserService();

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

        public IEnumerable<ReporteGrid> GetReportePorLlamadas()
        {
            var result = new List<ReporteGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from clie in db.Clientes
                        from llam in db.Llamadas.Where(x => x.Cliente_CUIT == clie.DNI)
                        select new ReportePorLlamadasGrid
                        {
                            ApyNom = clie.Nombre + " " + clie.Apellido,
                            TotalLlamadas = (
                                            from cli in db.Clientes
                                            from lla in db.Llamadas.Where(x => x.Cliente_CUIT == clie.DNI)
                                            select lla
                                            ).Count(),//contar la cantidad de llamadas del cliente
                            ClienteDNI = clie.DNI
                        }
                    ).OrderBy(x => x.Id).ToList();
            }

            return result;
        }

        public IEnumerable<ReporteGrid> GetMayorIngresosGenerados()
        {
            var result = new List<ReporteGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from clie in db.Clientes
                        from detall in db.Detalle
                        from fact in db.Factura.Where(x => x.idFactura == detall.idFactura)
                        from proyec in db.Proyecto.Where(x => x.idProyecto == detall.idProyecto) //
                        select new ReportePorIngresosGrid
                        {
                            ApyNom = clie.Nombre + " " + clie.Apellido,
                            TotalIngresos = (
                                            from clie in db.Clientes
                                            from detall in db.Detalle
                                            from fact in db.Factura.Where(x => x.idFactura == detall.idFactura)
                                            from proyec in db.Proyecto.Where(x => x.idProyecto == detall.idProyecto)
                                            select fact
                                            ).Sum(),
                            ClienteDNI = clie.DNI
                        }
                    ).OrderBy(x => x.Id).ToList();
            }

            return result;
        }
        public void Create(Reporte model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Reportes.Any(x => x.id == model.id))
                {
                    throw new Exception("Ya existe un empleado con id " + model.id);
                }
                var Reporte = new Reporte();

                Reporte.Id_cliente = model.Id_cliente;
                Reporte.NombreCliente = model.NombreCliente;


                db.Reportes.Add(Reporte);
                db.SaveChanges();
            }
        }

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

        public void Update(Reporte model)
        {
            var result = new List<Reporte>();

            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Reportes.Where(x => x.id == model.id).Single();

                //to do
                originalEntity.id = model.Id_cliente;
                originalEntity.nombre = model.NombreCliente;
                //to do

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        

        public UserPorEmp GetUser(int id)
        {
            var result = new UserPorEmp(); 

            using (var ctx = new ApplicationDbContext())
            {
                result = ctx.UserPorEmp.Where(x => x.id == id).FirstOrDefault();
            }

            return result;
        }


        public IEnumerable<ReporteGrid> Buscar(string palabra)
        {
            IEnumerable<ReporteGrid> Reporte;

            using (var db = new ApplicationDbContext())
            {
                Reporte = GetAll();
                if (!String.IsNullOrEmpty(palabra))
                {
                    Reporte = from emp in db.Empleado.Where(x => x.Nombre.ToUpper().Contains(palabra.ToUpper()) //COMO REEMPLAZO "EMPLEADO"?
                                || x.Apellido.ToUpper().Contains(palabra.ToUpper()))
                              from uxp in db.UserPorEmp.Where(x => x.Legajo == emp.Legajo).DefaultIfEmpty()
                              from us in db.ApplicationUsers.Where(x => x.Id == uxp.IdUsuario).DefaultIfEmpty()
                              from rol in db.RolEmpleado.Where(x => x.Id_Rol == emp.Id_RolServicio).DefaultIfEmpty()
                              select new ReporteGrid
                              {
                                  // to do
                              };
                }

                Reporte = Reporte.ToList();
            }

            return Reporte;
        }
    }
}
