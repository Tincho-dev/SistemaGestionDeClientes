using Model.Custom;
using Model.Domain;
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
        [Authorize]
        public ActionResult Index()
        {
            var listado = llamadaServices.GetAllLlamadasGrid();

            return View(listado);
        }

        // GET: Llamada/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            var model = llamadaServices.Get(id);
            return View("Details", model);
        }

        // GET: Llamada/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            return View();
        }

        // POST: Llamada/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Llamada llamada)
        {
            if (ModelState.IsValid)
            {
                llamadaServices.Create(llamada);
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom", llamada.Id_Cliente);

            return View(llamada);
        }

        // GET: Llamada/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var model = llamadaServices.GetEdit(id);
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente   ", "ApyNom");
            return View(model);
        }

        // POST: Llamada/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int id, Llamada llamada)
        {
            
                if (ModelState.IsValid)
                {
                    llamadaServices.Update(llamada);
                }

                return RedirectToAction("Index");
            
        }

        // GET: Llamada/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            var model = llamadaServices.Get(id);
            return View(model);
        }

        // POST: Llamada/Delete/5
        [Authorize]
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
        [Authorize]
        public ActionResult Reporte()
        {
            IEnumerable<ReportePorLlamadasGrid> llamadas;

            llamadas = reportesServices.GetReportePorLlamadas();

            return View("Reporte", llamadas);
        }
    }
}
