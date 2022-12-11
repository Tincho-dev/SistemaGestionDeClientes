﻿using Common;
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
        public IEnumerable<FacturaGrid> GetAll()
        {
            var result = new List<FacturaGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from fac in db.Facturas
                        from cli in db.Clientes.Where(x => x.Id == fac.Id_Cliente)
                        select new FacturaGrid
                        {
                            Id_Factura = fac.Id_Factura,
                            Id_Cliente = cli.DNI,
                            Total = fac.Total
                        }
                    ).Distinct().ToList();
            }

            return result;
        }

        public void Create(Factura model)
        {
            using (var db = new ApplicationDbContext())
            {
                var Factura = new Factura
                {
                    FechaEmision = model.FechaEmision,
                    FechaVencimiento = model.FechaVencimiento,
                    //Id_Proyecto = model.Id_Proyecto,
                    Id_Cliente = model.Id_Cliente,
                    LegajoEmpleado = (from emp in db.Empleado.Where(x => x.Nombre == CurrentUser.Get.Name)
                                      select emp.Legajo).Single()
                };
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
                          from det in db.Detalles.Where(x => x.Id_Factura == id)
                          from pro in db.Proyectos.Where(x => x.Id_Proyecto == det.Id_Proyecto)
                          from cli in db.Clientes.Where(x => x.Id == fac.Id_Cliente)

                          select new FacturaGrid
                          {
                              Id_Factura = fac.Id_Factura,
                              Id_Cliente = cli.DNI,
                              ApyNom = cli.Apellido + " " + cli.Nombre,
                              Total = fac.Total
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
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Facturas.Where(x => x.Id_Factura == model.Id_Factura).Single();

               
                var total = (from det in db.Detalles.Where(x => x.Id_Factura == model.Id_Factura)
                             select det.SubTotal);
                if(total.Count() > 0)
                {
                    originalEntity.Total = total.Sum();
                } else
                {
                    originalEntity.Total = 0;
                }
                originalEntity.Id_Factura = model.Id_Factura;
                originalEntity.Id_Cliente = model.Id_Cliente;
                originalEntity.FechaEmision = model.FechaEmision;
                originalEntity.FechaVencimiento = model.FechaVencimiento;
                originalEntity.LegajoEmpleado = model.LegajoEmpleado;

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
