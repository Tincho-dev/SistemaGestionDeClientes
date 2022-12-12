using Model.Domain;
using Persistanse;
using Services;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    public class DetalleController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly FacturaServices facturaServices = new FacturaServices();
        private readonly ClienteServices clienteServices = new ClienteServices();
        private readonly ProyectoServices proyectoServices = new ProyectoServices();
        private readonly DetalleServices detalleServices = new DetalleServices();

        //
        // GET: /Detalle/
        [Authorize]
        public ViewResult Index()
        {
            var Detalle = detalleServices.GetAll();
            return View(Detalle);
        }

        //
        // GET: /Detalle/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            var Detalle = detalleServices.Get(id);
            //return View("Details", model);// model?
             return View(Detalle);
        }

        //
        // GET: /Detalle/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Id_Factura = new SelectList(facturaServices.GetAll(), "Id_Factura", "Id_Factura");
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo");
            return View();
        }

        //
        // POST: /Detalle/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                detalleServices.Create(detalle);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo",detalle.Id_Proyecto);
            ViewBag.Id_Factura = new SelectList(facturaServices.GetAll(), "Id_Factura", "Id_Factura", detalle.Id_Factura);
            return View(detalle);
        }

        //
        // GET: /Detalle/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            Detalle Detalle = detalleServices.GetEdit(id);
            ViewBag.Id_Factura = new SelectList(facturaServices.GetAll(), "Id_Factura", "Id_Factura");
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo");
            return View(Detalle);
        }

        //
        // POST: /Detalle/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                detalleServices.Update(detalle);
                return RedirectToAction("Index");
            }
            ViewBag.Id_Proyecto = new SelectList(proyectoServices.GetAll(), "Id_Proyecto", "Titulo", detalle.Id_Proyecto);
            ViewBag.Id_Factura = new SelectList(facturaServices.GetAll(), "Id_Factura", "Id_Factura", detalle.Id_Factura);
            return View(detalle);
        }

        //
        // GET: /Detalle/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Detalle Detalle = db.Detalles.Find(id);
            return View(Detalle);
        }

        //
        // POST: /Detalle/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            detalleServices.Delete(id);
            return RedirectToAction("Index");
        }


    }

    
}
