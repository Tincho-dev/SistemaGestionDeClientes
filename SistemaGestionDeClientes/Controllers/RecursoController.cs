using Model.Custom;
using Model.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SisGestionDeProyectos.Controllers
{

    /*
    [Authorize(Roles = "Admin")]
    public class RecursoController : Controller
    {
        private readonly EmpleadoServices empleadoServices = new EmpleadoServices();
        private readonly RecursosServices recursosServices = new RecursosServices();
        private readonly TareasServices tareasServices = new TareasServices();
        private readonly RolesServices rolesServices = new RolesServices();
        // GET: Recurso
        public ActionResult Index()
        {
            List<SelectListItem> Opcion = new List<SelectListItem>()
            {
                new SelectListItem { Text="Todos", Value="1"},
                new SelectListItem { Text="Recurso Sobreasignado", Value="2" },
                new SelectListItem { Text = "Mayor Presupuesto", Value ="3" }
            };

            ViewBag.Opcion = Opcion;

            var model = recursosServices.GetAll();
            return View(model);
        }

        public ActionResult Buscar(string Opcion)
        {

            var recursos = recursosServices.Buscar(Opcion);

            List<SelectListItem> Opcion2 = new List<SelectListItem>()
            {
                new SelectListItem { Text="Todos", Value="1"},
                new SelectListItem { Text="Recurso Sobreasignado", Value="2" },
                new SelectListItem { Text = "Mayor Presupuesto", Value ="3" }
            };

            ViewBag.Opcion = Opcion2;

            Session["Opcion"] = Opcion;

            return View("Index", recursos);
        }

        // GET: Recurso/Details/5
        public ActionResult Details(int id)
        {
            var recurso = recursosServices.Get(id);
            return View("Details", recurso);
        }

        [Authorize(Roles = "Admin, Empleado")]
        public ActionResult RecursosXTarea(int id)
        {
            var tarea = tareasServices.Get(id);
            ViewBag.TareaGrid = tarea;
            Session["Id"] = id;

            var model = recursosServices.RecursosXTarea(id);
            return View(model);
        }

        public ActionResult Imprimir()
        {
            int id = int.Parse(Session["Id"].ToString());

            var tarea = tareasServices.Get(id);
            ViewBag.TareaGrid = tarea;

            var model = recursosServices.RecursosXTarea(id);
            return View(model);
        }

        // GET: Recurso/Create
        public ActionResult Create()
        {

            ViewBag.Legajo = new SelectList(empleadoServices.GetAll(), "Legajo", "ApyNom");
            ViewBag.Id_Tarea = new SelectList(tareasServices.GetCbo(), "Id_Tarea", "NomTarea");
            return View();
        }

        // POST: Recurso/Create
        [HttpPost]
        public ActionResult Create(Recurso recurso)
        {
            var recursos = recursosServices.ObtenerRecurso(recurso.Id_Tarea, recurso.Legajo);

            if(recursos != null)
            {
                throw new Exception("Este recurso ya se asigno a esta Tarea");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    recursosServices.Create(recurso);
                    return RedirectToAction("Index");
                }
            }


            ViewBag.Legajo = new SelectList(empleadoServices.GetAll(), "Legajo", "ApyNom", recurso.Legajo);
            ViewBag.Id_Tarea = new SelectList(tareasServices.GetCbo(), "Id_Tarea", "NomTarea", recurso.Id_Tarea);

            return View(recurso);
        }

        // GET: Recurso/Edit/5
        public ActionResult Edit(int id)
        {
            var model = recursosServices.GetEdit(id);
            ViewBag.Legajo = new SelectList(empleadoServices.GetAll(), "Legajo", "ApyNom");
            ViewBag.Id_Tarea = new SelectList(tareasServices.GetCbo(), "Id_Tarea", "NomTarea");
            return View(model);
        }

        // POST: Recurso/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Recurso recurso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    recursosServices.Update(recurso);
                }

                ViewBag.Legajo = new SelectList(empleadoServices.GetAll(), "Legajo", "ApyNom", recurso.Legajo);
                ViewBag.Id_Tarea = new SelectList(tareasServices.GetCbo(), "Id_Tarea", "NomTarea", recurso.Id_Tarea);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recurso/Delete/5
        public ActionResult Delete(int id)
        {
            var model = recursosServices.Get(id);
            return View(model);
        }

        // POST: Recurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                recursosServices.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Reporte()
        {
            IEnumerable<RecursoGrid> recursos;

            if (Session["Opcion"] != null)
            {
                string Opcion = Session["Opcion"].ToString();

                recursos = recursosServices.Buscar(Opcion);
            }
            else
            {
                recursos = recursosServices.GetAll();
            }
            return View("Reporte", recursos);
        }
    }
     */
}
