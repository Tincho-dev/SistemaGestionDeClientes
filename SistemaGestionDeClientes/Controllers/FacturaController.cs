using Model.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionDeFacturas.Controllers
{

    public class FacturaController : Controller
    {
        private readonly FacturaServices _FacturaService = new FacturaServices();

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
        public ActionResult Create(Factura Factura)
        {
            _FacturaService.Create(Factura);
            return RedirectToAction("Index");
        }

        // POST: Factura/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _FacturaService.GetEdit(id);
            return View(model);
        }

        // POST: Factura/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Factura Factura)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _FacturaService.Update(Factura);
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
