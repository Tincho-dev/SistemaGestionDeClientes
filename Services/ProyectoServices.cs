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
                result = (from cli in db.Clientes
                          from pr in db.Proyectos.Where(x => x.Cliente_DNI == cli.DNI)
                          select new ProyectosGrid
                          {
                              Id_Proyecto = pr.Id_Proyecto,
                              Titulo = pr.Titulo,
                              Descripcion = pr.Descripcion,
                              FechInicio = pr.FechInicio,
                              FechFin = pr.FechFin,
                              ClienteDNI = cli.DNI,
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
                          from cli in db.Clientes.Where(x => x.Id == pr.Cliente_DNI)
                          select new ProyectosGrid
                          {
                              Id_Proyecto = pr.Id_Proyecto,
                              Titulo = pr.Titulo,
                              Descripcion = pr.Descripcion,
                              FechInicio = pr.FechInicio,
                              FechFin = pr.FechFin,
                              ClienteDNI = (from clie in db.Clientes.Where(x => x.Id == pr.Cliente_DNI)
                                            select clie.DNI).Single(),
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
                proyecto.FechInicio = model.FechInicio;
                proyecto.FechFin = model.FechFin;
                proyecto.Cliente_DNI = (
                        from clie in db.Clientes.Where(x => x.DNI == model.Cliente_DNI)
                        select clie.Id).Single();
                proyecto.Costo = model.Costo;
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

                originalEntity.Titulo = model.Titulo;
                originalEntity.Descripcion = model.Descripcion;
                originalEntity.FechFin = model.FechFin;
                originalEntity.Cliente_DNI = model.Cliente_DNI;

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
                               from cli in db.Clientes.Where(x => x.DNI == pr.Cliente_DNI)
                               select new ProyectosGrid
                               {
                                   Id_Proyecto = pr.Id_Proyecto,
                                   Titulo = pr.Titulo,
                                   Descripcion = pr.Descripcion,
                                   FechInicio = pr.FechInicio,
                                   FechFin = pr.FechFin,
                                   ClienteDNI = cli.DNI,
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

        public void UpdateCosto(int id, double costo)
        {
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Proyectos.Where(x => x.Id_Proyecto == id).Single();

                originalEntity.Costo = costo;

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
