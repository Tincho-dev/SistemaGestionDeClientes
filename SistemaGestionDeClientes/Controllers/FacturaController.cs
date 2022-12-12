using Model.Domain;
using Persistanse;
using Services;
using System.Threading.Tasks;
using System.Web.Mvc;
//using Microsoft.AspNetCore.Hosting;

namespace SistemaGestionDeClientes.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly EmpleadoServices empleadoServices = new EmpleadoServices();
        private readonly ClienteServices clienteServices= new ClienteServices();
        private readonly ProyectoServices proyectoServices= new ProyectoServices();
        private readonly FacturaServices facturaServices= new FacturaServices();
        private readonly DetalleServices detallesServices= new DetalleServices();

        [Authorize]
        public ViewResult Index()
        {
            var Facturas = facturaServices.GetAll();
            return View(Facturas);
        }




        // GET: /Factura/Details/5
        [Authorize]
        public ViewResult Print(int id)
        {
            ViewBag.Print = true;
            Factura invoice = db.Facturas.Find(id);
            return View(invoice);
        }

        [Authorize]
        public ActionResult Imprimir(int id)
        {
            var factura = facturaServices.Get(id);
            ViewBag.FacturaGrid = factura;

            var model = detallesServices.DetallesDeFactura(id);

            facturaServices.Emitir(db.Facturas.Find(id));

            foreach (var det in db.Facturas.Find(id).DetallesFactura)
            {
                detallesServices.Emitir(det);
            }

            return View(model);
        }

        //
        // GET: /Factura/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(clienteServices.GetAll(), "Id_Cliente", "ApyNom");
            ViewBag.LegajoEmpleado = new SelectList(empleadoServices.GetAll(), "LegajoEmpleado", "ApyNom");
            return View();
        }


        //
        // POST: /Factura/Create
        [Authorize]
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

        

        [Authorize]
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
}
