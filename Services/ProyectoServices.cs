using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class ProyectoServices
    {
        public IEnumerable<ProyectosGrid> GetAll()
        {
            var result = new List<ProyectosGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                          from pr in db.Proyectos
                          from clie in db.Clientes.Where(x => x.Id == pr.Id_Cliente)
                          select new ProyectosGrid
                          {
                              Id_Proyecto = pr.Id_Proyecto,
                              Titulo = pr.Titulo,
                              Descripcion = pr.Descripcion,
                              FechaInicio = pr.FechaInicio,
                              FechaFin = pr.FechaFin,
                              Id_Cliente = clie.DNI,
                              Costo = pr.Costo
                          }
                          ).ToList();
            }
            return result;
        }

        

        public ProyectosGrid Get(int id)
        {
            var result = new ProyectosGrid();

            using (var db = new ApplicationDbContext())
            {
                result = (from pr in db.Proyectos.Where(x => x.Id_Proyecto == id)
                          from clie in db.Clientes.Where(x => x.Id == pr.Id_Cliente)
                          select new ProyectosGrid
                          {
                              Id_Proyecto = pr.Id_Proyecto,
                              Titulo = pr.Titulo,
                              Descripcion = pr.Descripcion,
                              FechaInicio = pr.FechaInicio,
                              FechaFin = pr.FechaFin,
                              Id_Cliente = clie.Id,
                              Costo = pr.Costo
                          }
                          ).Single();
            }

            return result;
        }

        public Proyectos GetEdit(int id)
        {
            var result = new Proyectos();

            using (var db = new ApplicationDbContext())
            {
                result = db.Proyectos.Where(x => x.Id_Proyecto == id).Single();
            }

            return result;
        }

        public void Create(Proyectos model)
        {
            using (var db = new ApplicationDbContext())
            {
                var proyecto = new Proyectos();

                proyecto.Titulo = model.Titulo;
                proyecto.Descripcion = model.Descripcion;
                proyecto.FechaInicio = model.FechaInicio;
                proyecto.FechaFin = model.FechaFin;
                proyecto.Id_Cliente = model.Id_Cliente;
                proyecto.Finalizado = false;

                db.Proyectos.Add(proyecto);
                db.SaveChanges();
            }
        }

        public void Update(Proyectos model) 
        {
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Proyectos.Where(x => x.Id_Proyecto == model.Id_Proyecto).Single();
                
                var total = (from det in db.Detalles.Where(x=>x.Id_Proyecto == model.Id_Proyecto)
                             from fac in db.Facturas.Where(x=> x.Id_Factura == det.Id_Factura)
                             select fac.Total);
                if (total.Count() > 0)
                {
                    originalEntity.Costo = total.Sum();
                }
                else
                {
                    originalEntity.Costo = 0;
                }
                originalEntity.Titulo = model.Titulo;
                originalEntity.Descripcion = model.Descripcion;
                originalEntity.FechaFin = model.FechaFin;
                originalEntity.Id_Cliente = model.Id_Cliente;

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        
        public void Asociar(Proyectos model)
        {
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Proyectos.Where(x => x.Id_Proyecto == model.Id_Proyecto).Single();

                
                originalEntity.Id_Cliente = model.Id_Cliente;

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
                    Proyectos proyectos = db.Proyectos.Where(x => x.Id_Proyecto == id).Single();

                    db.Proyectos.Remove(proyectos);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<ProyectosGrid> Buscar(string palabra, string value)
        {
            var FechaActual = DateTime.Parse(DateTime.Today.ToShortDateString());
            var db = new ApplicationDbContext();
            IEnumerable<ProyectosGrid> proyecto;

            ProyectosGrid proyectos = new ProyectosGrid();

            using (db)
            {
                proyecto = GetAll();

                if (!String.IsNullOrEmpty(palabra))
                {
                    proyecto = from pr in db.Proyectos.Where(x => x.Titulo.ToUpper().Contains(palabra.ToUpper()))
                               from cli in db.Clientes.Where(x => x.Id == pr.Id_Cliente)
                               select new ProyectosGrid
                               {
                                   Id_Proyecto = pr.Id_Proyecto,
                                   Titulo = pr.Titulo,
                                   Descripcion = pr.Descripcion,
                                   FechaInicio = pr.FechaInicio,
                                   FechaFin = pr.FechaFin,
                                   Id_Cliente = cli.DNI,
                                   Costo = pr.Costo
                               };
                }

                proyecto = proyecto.ToList();
            }

            return proyecto;
        }

        public void UpdateAvance(int id, bool Avance)
        {
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Proyectos.Where(x => x.Id_Proyecto == id).Single();

                originalEntity.Finalizado = Avance;

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
