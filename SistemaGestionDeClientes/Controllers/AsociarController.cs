using Persistanse;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    public class AsociarController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly EmpleadoServices empleadoServices = new EmpleadoServices();
        private readonly ClienteServices clienteServices = new ClienteServices();
        private readonly ProyectoServices proyectoServices = new ProyectoServices();

        // GET: Asociar
        public ActionResult Index()
        {
            return View();
        }

        // GET: Asociar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asociar/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo");
            return View();
        }

        // POST: Asociar/Create
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

        // GET: Asociar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asociar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Asociar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asociar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
