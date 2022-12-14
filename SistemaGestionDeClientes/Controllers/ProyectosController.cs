using Model.Custom;
using Model.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly ProyectoServices proyectoservice = new ProyectoServices();
        private readonly ClienteServices clienteServices = new ClienteServices();

        // GET: Proyectos
        [Authorize]
        public ActionResult Index()
        {
            var listado = proyectoservice.GetAll();

            return View(listado);
        }

        [Authorize]
        public ActionResult Buscar(string palabra, string Fecha)
        {
            var proyectos = proyectoservice.Buscar(palabra, Fecha);

            Session["Palabra"] = palabra;
            Session["Fecha"] = Fecha;

            return View("Index", proyectos);
        }

        [Authorize]
        // GET: Proyectos/Details/5
        public ActionResult Details(int id)
        {
            var model = proyectoservice.Get(id);
            return View("Details", model);
        }

        [Authorize]
        // GET: Proyectos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            return View();
        }

        [Authorize]
        // POST: Proyectos/Create
        [HttpPost]
        public ActionResult Create(Proyectos proyecto)
        {
            if (ModelState.IsValid)
            {
                proyectoservice.Create(proyecto);
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom", proyecto.Id_Cliente);

            return View(proyecto);
        }



        [Authorize]
        // GET: Proyectos/AsociarCliente/5
        public ActionResult AsociarCliente(int id)
        {
            var model = proyectoservice.GetEdit(id);
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            ViewBag.Id_Proyecto = new SelectList(proyectoservice.GetAll(), "Id_Proyecto", "Titulo");
            return View(model);
        }

        [Authorize]
        // POST: Proyectos/AsociarCliente/5
        [HttpPost]
        public ActionResult AsociarCliente(int id, Proyectos proyecto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    proyectoservice.Asociar(proyecto);
                }

                ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom", proyecto.Id_Cliente);
                ViewBag.Id_Proyecto = new SelectList(proyectoservice.GetAll(), "Id_Proyecto", "Titulo", proyecto.Id_Proyecto);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        [Authorize]
        // GET: Proyectos/Edit/5
        public ActionResult Edit(int id)
        {
            var model = proyectoservice.GetEdit(id);
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            return View(model);
        }

        [Authorize]
        // POST: Proyectos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Proyectos proyecto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    proyectoservice.Update(proyecto);
                }

                ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom", proyecto.Id_Cliente);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [Authorize]
        // GET: Proyectos/Delete/5
        public ActionResult Delete(int id)
        {
            var model = proyectoservice.Get(id);
            return View(model);
        }

        [Authorize]
        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                proyectoservice.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //Reportes
        [Authorize]
        public ActionResult Reporte()
        {
            IEnumerable<ProyectosGrid> proyectos;

            if (Session["Palabra"] != null)
            {
                string palabra = Session["Palabra"].ToString();
                string Fecha = Session["Fecha"].ToString();

                proyectos = proyectoservice.Buscar(palabra, Fecha);
            }
            else
            {
                proyectos = proyectoservice.GetAll();
            }

            return View("Reporte", proyectos);
        }
    }
}
