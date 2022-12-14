using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Services
{
    public class ClienteServices
    {
        private readonly UserService userService = new UserService();
        
        public IEnumerable<ClienteGrid> GetAll()
        {
            var result = new List<ClienteGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from cli in db.Clientes
                        select new ClienteGrid
                        {
                            Id_Cliente = cli.Id,
                            DNI = cli.DNI,
                            ApyNom = cli.Nombre + " " + cli.Apellido,
                            FechaNacimiento = cli.FechaNacimiento,
                            Telefono = cli.Telefono,
                            Mail = cli.Mail,
                            ProyectosAsociados = (from proy in db.Proyectos.Where(x=> x.Id_Cliente == cli.Id) 
                                                  select proy).Count()
                            
                        }
                    ).OrderBy(x => x.DNI).ToList();
            }

            return result;
        }

        public void Create(Cliente model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Clientes.Any(x => x.DNI == model.DNI))
                {
                    throw new Exception("Ya existe un empleado con DNI " + model.DNI);
                }
                var cliente = new Cliente();

                cliente.Nombre = model.Nombre;
                cliente.Apellido = model.Apellido;
                cliente.DNI = model.DNI;
                cliente.Condicion_Tributaria = model.Condicion_Tributaria;
                cliente.FechaNacimiento = model.FechaNacimiento;
                cliente.Mail = model.Mail;
                cliente.Telefono = model.Telefono;


                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }

        public ClienteGrid Get(int id)
        {
            var result = new ClienteGrid();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from clie in db.Clientes.Where(x => x.Id == id)
                        select new ClienteGrid
                        {
                            DNI = clie.DNI,
                            ApyNom = clie.Nombre + " " + clie.Apellido,
                            Telefono = clie.Telefono,
                            Mail = clie.Mail,
                            FechaNacimiento = clie.FechaNacimiento 
                        }
                    ).Single();
            }

            return result;
        }

        public Cliente GetEdit(int id)
        {
            var result = new Cliente();

            using (var db = new ApplicationDbContext())
            {
                result = db.Clientes.Where(x => x.Id == id).Single();
            }
            return result;
        }

        public IEnumerable<ProyectosGrid> GetProyectos(int id)
        {
            var result = new List<ProyectosGrid>();

            using (var db = new ApplicationDbContext())
            {
                result = (
                          from pr in db.Proyectos.Where(x => x.Id_Cliente == id)
                          select new ProyectosGrid
                          {
                              Id_Proyecto = pr.Id_Proyecto,
                              Titulo = pr.Titulo,
                              Descripcion = pr.Descripcion,
                              FechaInicio = pr.FechaInicio,
                              FechaFin = pr.FechaFin,
                              Id_Cliente = pr.Id_Cliente,
                              Costo = pr.Costo
                          }
                          ).ToList();
            }
            return result;
        }

        public void Update(Cliente model)
        {
            var result = new List<Cliente>();

            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Clientes.Where(x => x.Id == model.Id).Single();

                originalEntity.Condicion_Tributaria = model.Condicion_Tributaria;
                originalEntity.Nombre = model.Nombre;
                originalEntity.Apellido = model.Apellido;
                originalEntity.DNI = model.DNI;
                originalEntity.FechaNacimiento = model.FechaNacimiento;
                originalEntity.Mail = model.Mail;
                originalEntity.Telefono = model.Telefono;

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
                    Cliente cliente = db.Clientes.Where(x => x.Id == id).Single();

                    db.Clientes.Remove(cliente);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        
        public IEnumerable<ClienteGrid> Buscar(string palabra)
        {
            IEnumerable<ClienteGrid> cliente;

            using (var db = new ApplicationDbContext())
            {
                cliente = GetAll();
                if (!String.IsNullOrEmpty(palabra))
                {
                    cliente = from clie in db.Clientes.Where(x => x.Nombre.ToUpper().Contains(palabra.ToUpper()))
                              select new ClienteGrid
                              {
                                  Id_Cliente = clie.Id,
                                   DNI = clie.DNI,
                                   ApyNom = clie.Nombre + " " + clie.Apellido,
                                   Telefono = clie.Telefono,
                                   Mail = clie.Mail,
                                   FechaNacimiento = clie.FechaNacimiento
                               };
                }

                cliente = cliente.ToList();
            }

            return cliente;
        }

    }
}

