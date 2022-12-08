using Model.Custom;
using Model.Domain;
using Persistanse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                            DNI = cli.DNI,
                            ApyNom = cli.Nombre + " " + cli.Apellido,
                            FechaNacimiento = cli.FechaNacimiento,

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


                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }

        public ClienteGrid Get(int legajo)
        {
            var result = new ClienteGrid();

            using (var db = new ApplicationDbContext())
            {
                result = (
                        from emp in db.Empleado.Where(x => x.Legajo == legajo)
                        from uxp in db.UserPorEmp.Where(x => x.Legajo == emp.Legajo).DefaultIfEmpty()
                        from us in db.ApplicationUsers.Where(x => x.Id == uxp.IdUsuario).DefaultIfEmpty()
                        from rol in db.RolEmpleado.Where(x => x.Id_Rol == emp.Id_RolServicio).DefaultIfEmpty()
                        select new ClienteGrid
                        {

                        }
                    ).Single();
            }

            return result;
        }

        public Cliente GetEdit(int dni)
        {
            var result = new Cliente();

            using (var db = new ApplicationDbContext())
            {
                result = db.Clientes.Where(x => x.DNI == dni).Single();
            }
            return result;
        }

        public void Update(Cliente model)
        {
            var result = new List<Cliente>();

            using (var db = new ApplicationDbContext())
            {
                var originalEntity = db.Clientes.Where(x => x.DNI == model.DNI).Single();

                //to do
                originalEntity.Nombre = model.Nombre;
                originalEntity.Apellido = model.Apellido;
                //to do

                db.Entry(originalEntity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int legajo)
        {
            try
            {
                using (var db = new ApplicationDbContext())
                {
                    Empleado empleado = db.Empleado.Where(x => x.Legajo == legajo).Single();

                    db.Empleado.Remove(empleado);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public UserPorEmp GetUser(int legajo)
        {
            var result = new UserPorEmp();

            using (var ctx = new ApplicationDbContext())
            {
                result = ctx.UserPorEmp.Where(x => x.Legajo == legajo).FirstOrDefault();
            }

            return result;
        }

        
        public IEnumerable<ClienteGrid> Buscar(string palabra)
        {
            IEnumerable<ClienteGrid> cliente;

            using (var db = new ApplicationDbContext())
            {
                cliente = GetAll();
                if (!String.IsNullOrEmpty(palabra))
                {
                    cliente = from emp in db.Empleado.Where(x => x.Nombre.ToUpper().Contains(palabra.ToUpper())
                                || x.Apellido.ToUpper().Contains(palabra.ToUpper()))
                               from uxp in db.UserPorEmp.Where(x => x.Legajo == emp.Legajo).DefaultIfEmpty()
                               from us in db.ApplicationUsers.Where(x => x.Id == uxp.IdUsuario).DefaultIfEmpty()
                               from rol in db.RolEmpleado.Where(x => x.Id_Rol == emp.Id_RolServicio).DefaultIfEmpty()
                               select new ClienteGrid
                               {
                                   // to do
                               };
                }

                cliente = cliente.ToList();
            }

            return cliente;
        }

    }
}

