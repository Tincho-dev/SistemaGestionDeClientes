using Model.Domain;
using Services;
using System;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        private readonly ClienteServices clienteServices = new ClienteServices();

        // GET: Cliente
        public ActionResult Index()
        {
            var listado = clienteServices.GetAll();

            return View(listado);
        }

        public ActionResult Buscar(string palabra)
        {
            var empleados = clienteServices.Buscar(palabra);

            Session["Palabra"] = palabra;

            return View("Index", empleados);
        }
        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var model = clienteServices.Get(id);
            return View("Details", model);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteServices.Create(cliente);
                return RedirectToAction("Index");
            }

            //ViewBag.ClienteDNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom", proyecto.Cliente_DNI);

            return View(cliente);
        }


        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var model = clienteServices.GetEdit(id);
            ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View(model);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clienteServices.Update(cliente);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var model = clienteServices.Get(id);
            return View(model);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                clienteServices.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

