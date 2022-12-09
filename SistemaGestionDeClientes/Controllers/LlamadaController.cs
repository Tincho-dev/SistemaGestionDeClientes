using Model.Custom;
using Model.Domain;
using Persistanse;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    public class LlamadaController : Controller
    {
        private readonly LlamadaServices llamadaServices = new LlamadaServices();
        private readonly ClienteServices clienteServices = new ClienteServices();
        private readonly ReportesServices reportesServices = new ReportesServices();

        // GET: Llamada
        public ActionResult Index()
        {
            var listado = llamadaServices.GetAll();

            return View(listado);
        }

        // GET: Llamada/Details/5
        public ActionResult Details(int id)
        {
            var model = llamadaServices.Get(id);
            return View("Details", model);
        }

        // GET: Llamada/Create
        public ActionResult Create()
        {
            ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View();
        }

        // POST: Llamada/Create
        [HttpPost]
        public ActionResult Create(Llamada llamada)
        {
            if (ModelState.IsValid)
            {
                llamadaServices.Create(llamada);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteDNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom", llamada.Cliente_CUIT);

            return View(llamada);
        }

        // GET: Llamada/Edit/5
        public ActionResult Edit(int id)
        {
            var model = llamadaServices.GetEdit(id);
            ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View(model);
        }

        // POST: Llamada/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Llamada llamada)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    llamadaServices.Update(llamada);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Llamada/Delete/5
        public ActionResult Delete(int id)
        {
            var model = llamadaServices.Get(id);
            return View(model);
        }

        // POST: Llamada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                llamadaServices.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Reportes
        //[Authorize]
        public ActionResult Reporte()
        {
            IEnumerable<ReportePorLlamadasGrid> llamadas;

            llamadas = reportesServices.GetReportePorLlamadas();

            return View("Reporte", llamadas);
        }
    }
}
