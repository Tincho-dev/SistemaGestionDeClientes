using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class FacturaServices
    {
        //private readonly FacturaServices userService = new FacturaServices();

        public IEnumerable<FacturaGrid> GetAll()
        {
            var result = new List<FacturaGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from fac in db.Facturas
                        from hist in db.Historiales.Where(x => x.Id_Historial == fac.Id_Historial)
                        from pro in db.Proyectos.Where(x => x.Id_Proyecto == hist.Id_Historial)
                        from cli in db.Clientes.Where(x => x.DNI == hist.Cliente_DNI)
                        select new FacturaGrid
                        {
                            Id_Factura = fac.Id_Factura,
                            ClienteDNI = cli.DNI,
                            NombreProyecto = pro.Titulo
                        }
                    ).ToList();
            }

            return result;
        }
        public void Create(Factura model)
        {
            using (var db = new ApplicationDbContext())
            {
                var Factura = new Factura();
                Factura.Empleado = model.Empleado;
                Factura.FechaEmision = model.FechaEmision;
                Factura.FechaVencimiento = model.FechaVencimiento;
                Factura.Historial = model.Historial;
                Factura.Id_Factura = model.Id_Factura;
                Factura.LegajoEmpleado = Factura.LegajoEmpleado;
                Factura.Total = model.Total;
                Factura.RutaCopiaOriginal = model.RutaCopiaOriginal;

                db.Facturas.Add(Factura);
                db.SaveChanges();
            }
        }

        public FacturaGrid Get(int id)
        {
            var result = new FacturaGrid();

            using (var db = new ApplicationDbContext())
            {
                result = (from fac in db.Facturas.Where(x => x.Id_Factura == id).DefaultIfEmpty()
                          from hist in db.Historiales.Where(x => x.Id_Historial == fac.Id_Historial)
                          from pro in db.Proyectos.Where(x => x.Id_Proyecto == hist.Id_Historial)
                          from cli in db.Clientes.Where(x => x.DNI == hist.Cliente_DNI)

                          select new FacturaGrid
                          {
                              Id_Factura = fac.Id_Factura,
                              ClienteDNI = cli.DNI,
                              NombreProyecto = pro.Titulo
                          }
                        ).Single();
            }

            return result;
        }

        public Factura GetEdit(int id)
        {
            var result = new Factura();

            using (var db = new ApplicationDbContext())
            {
                result = db.Facturas.Where(x => x.Id_Factura == id).Single();
            }
            return result;
        }

        public void Update(Factura model)
        {
            var result = new List<Factura>();

            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Facturas.Where(x => x.Id_Factura == model.Id_Factura).Single();

                originalEntity.Id_Factura = model.Id_Factura;
                originalEntity.Id_Historial = model.Id_Historial;
                originalEntity.LegajoEmpleado = model.LegajoEmpleado;
                originalEntity.RutaCopiaOriginal = model.RutaCopiaOriginal;
                originalEntity.Total = model.Total;

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    Factura factura = db.Facturas.Where(x => x.Id_Factura == id).Single();

                    db.Facturas.Remove(factura);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
