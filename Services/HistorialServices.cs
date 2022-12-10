using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class HistorialServices
    {/*
        //private readonly HistorialServices userService = new HistorialServices();

        public IEnumerable<HistorialesGrid> GetAll()
        {
            var result = new List<HistorialesGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (

                    ).ToList();
            }

            return result;
        }
        public HistorialesGrid Get(int id)
        {
            var result = new HistorialesGrid();

            using (var db = new ApplicationDbContext())
            {
                result = (from his in db.Historiales.Where(x => x.Id_Historial == id)
                          select new HistorialesGrid
                          {
                              id = his.Id_Historial,
                              SueldoAdeudado = his.SaldoAdeudado
                          }
                          ).Single();
            }

            return result;
        }

        public Historial GetEdit(int id)
        {
            var result = new Historial();

            using (var db = new ApplicationDbContext())
            {
                result = db.Historiales.Where(x => x.Id_Historial == id).Single();
            }

            return result;
        }

        public void Create(Historial model)
        {
            using (var db = new ApplicationDbContext())
            {
                var historial = new Historial();

                historial.SaldoAdeudado = model.SaldoAdeudado;

                db.Historiales.Add(historial);
                db.SaveChanges();
            }
        }

        public void Update(Historial model)
        {
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Historiales.Where(x => x.Id_Historial == model.Id_Historial).Single();

                originalEntity.SaldoAdeudado = model.SaldoAdeudado;

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
                    Historial historiales = db.Historiales.Where(x => x.Id_Historial == id).Single();

                    db.Historiales.Remove(historiales);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        /*
        public IEnumerable<HistorialesGrid> Buscar(string palabra, string value)
        {
            var FechaActual = DateTime.Parse(DateTime.Today.ToShortDateString());
            var db = new ApplicationDbContext();
            IEnumerable<HistorialesGrid> historial;

            HistorialesGrid historial = new HistorialesGrid();

            using (db)
            {
                historial = GetAll();

                if (!String.IsNullOrEmpty(palabra))
                {
                    historial = from pr in db.Historiales.Where(x => x.SaldoAdeudado.Contains(palabra.ToUpper()))
                               from cli in db.Historiales.Where(x => x.Id_Historial == pr.id_historial)
                               select new HistorialesGrid
                               {
                                   id = pr.Id_Historial,
                                   SueldoAdeudado = pr.sueldoAdeudado,
                                   
                               };
                }

                if (value == "2")
                {

                    historial = from pr in db.Historiales.Where(x => x.FechFin < FechaActual)
                               from cli in db.Clientes.Where(x => x.DNI == pr.Cliente_DNI)
                               select new HistorialesGrid
                               {
                                   Id_Historial = pr.Id_Historial,
                                   SueldoAdeudado = pr.sueldoAdeudado,
                               };
                }

                if (value == "3")
                {

                    historial = from pr in db.Historiales.Where(x => x.FechInicio > FechaActual)
                               from cli in db.Clientes.Where(x => x.DNI == pr.Cliente_DNI)
                               select new HistorialesGrid
                               {
                                   Id_Historial = pr.Id_Historial,
                                   SueldoAdeudado = pr.sueldoAdeudado,
                               };
                }

                historial = historial.ToList();
            }

            return historial;
        }

        
        public void UpdateCosto(int id, double costo)
        {
            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Historiales.Where(x => x.Id_Historial == id).Single();

                originalEntity.SaldoAdeudado = costo;

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
      */
    }
}
