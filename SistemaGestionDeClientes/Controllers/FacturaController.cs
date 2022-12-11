using Model.Domain;
using Persistanse;
using Services;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly EmpleadoServices empleadoServices = new EmpleadoServices();
        private readonly ClienteServices clienteServices= new ClienteServices();
        private readonly ProyectoServices proyectoServices= new ProyectoServices();
        private readonly FacturaServices facturaServices= new FacturaServices();

        //
        // GET: /Factura/

        public ViewResult Index()
        {
            var Facturas = facturaServices.GetAll();
            return View(Facturas);
        }

        //
        // GET: /Factura/Details/5

        public ViewResult Details(int id)
        {
            var Factura = facturaServices.Get(id);
            return View(Factura);
        }

        //
        // GET: /Factura/Create

        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo");
            ViewBag.LegajoEmpleado = new SelectList(empleadoServices.GetAll(), "LegajoEmpleado", "ApyNom");
            return View();
        }

        //
        // POST: /Factura/Create

        [HttpPost]
        public ActionResult Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                facturaServices.Create(factura);
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id", "ApyNom",factura.Id_Cliente);
            ViewBag.LegajoEmpleado = new SelectList(empleadoServices.GetAll(), "Legajo", "ApyNom",factura.LegajoEmpleado);
            return View(factura);
        }

        //
        // GET: /Factura/Edit/5

        public ActionResult Edit(int id)
        {
            Factura Factura = facturaServices.GetEdit(id);
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo");
            ViewBag.LegajoEmpleado = new SelectList(empleadoServices.GetAll(), "LegajoEmpleado", "ApyNom");
            return View(Factura);
        }

        //
        // POST: /Factura/Edit/5

        [HttpPost]
        public ActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                facturaServices.Update(factura);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id", "ApyNom", factura.Id_Cliente);
            ViewBag.LegajoEmpleado = new SelectList(empleadoServices.GetAll(), "Legajo", "ApyNom", factura.LegajoEmpleado);
            return View(factura);
        }

        //
        // GET: /Factura/Delete/5

        public ActionResult Delete(int id)
        {
            var model = facturaServices.Get(id);
            return View(model);
        }

        //[Authorize(Roles = "Admin")]
        // POST: Proyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                facturaServices.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }


    /*
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
     */
}
