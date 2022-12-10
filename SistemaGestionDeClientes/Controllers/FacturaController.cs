using Model.Domain;
using Services;
using System;
using System.Web.Mvc;

namespace SistemaGestionDeFacturas.Controllers
{

    public class FacturaController : Controller
    {
        private readonly FacturaServices _FacturaService = new FacturaServices();
        private readonly ClienteServices clienteServices = new ClienteServices();
        private readonly ProyectoServices proyectoServices = new ProyectoServices();

        // GET: Factura
        public ActionResult Index()
        {
            var listado = _FacturaService.GetAll();

            return View(listado);
        }


        // GET: Factura/Details/5
        public ActionResult Details(int id)
        {
            var model = _FacturaService.Get(id);
            return View("Details", model);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo");

            return View();
        }

        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                _FacturaService.Create(factura);
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente  = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom", factura.Id_Cliente);
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo", factura.Id_Proyecto);

            return View(factura);
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _FacturaService.GetEdit(id);
            ViewBag.DNI = new SelectList(clienteServices.GetAll(), "DNI", "ApyNom");
            return View(model);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Factura factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _FacturaService.Update(factura);
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _FacturaService.Get(id);
            return View(model);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _FacturaService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
