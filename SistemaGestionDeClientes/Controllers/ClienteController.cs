using Model.Custom;
using Model.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        private readonly ClienteServices clienteServices = new ClienteServices();
        private readonly ReportesServices reportesServices = new ReportesServices();

        // GET: Cliente
        [Authorize]
        public ActionResult Index()
        {
            var listado = clienteServices.GetAll();

            return View(listado);
        }

        [Authorize]
        public ActionResult GetProyectos(int id)
        {
            var listado = clienteServices.GetProyectos(id);

            return View(listado);
        }

        [Authorize]
        public ActionResult Buscar(string palabra)
        {
            var empleados = clienteServices.Buscar(palabra);

            Session["Palabra"] = palabra;

            return View("Index", empleados);
        }
        // GET: Cliente/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var model = clienteServices.Get(id);
            return View("Details", model);
        }

        // GET: Cliente/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [Authorize]
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
        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = clienteServices.GetEdit(id);
            //ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View(model);
        }

        // POST: Cliente/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {

            if (ModelState.IsValid)
            {
                clienteServices.Update(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = clienteServices.Get(id);
            return View(model);
        }

        // POST: Cliente/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clienteServices.Delete(id);
            return RedirectToAction("Index");
        }

        //Reportes
        [Authorize]
        public ActionResult Reporte()
        {
            IEnumerable<ReportePorIngresosGrid> ingresos;

            ingresos = reportesServices.GetMayorIngresosGenerados();

            return View("Reporte", ingresos);
        }

    }
}

