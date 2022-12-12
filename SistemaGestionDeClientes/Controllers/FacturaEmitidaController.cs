using Model.Domain;
using Persistanse;
using Services;
using System.Threading.Tasks;
using System.Web.Mvc;
//using Microsoft.AspNetCore.Hosting;

namespace SistemaGestionDeClientes.Controllers
{
    public class FacturaEmitidaController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly EmpleadoServices empleadoServices = new EmpleadoServices();
        private readonly ClienteServices clienteServices = new ClienteServices();
        private readonly ProyectoServices proyectoServices = new ProyectoServices();
        private readonly FacturaServices facturaServices = new FacturaServices();
        private readonly DetalleServices detallesServices = new DetalleServices();
         
        [Authorize]
        public ViewResult Index()
        {
            var Facturas = facturaServices.GetAllEmitidas();
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

            var model = detallesServices.DetallesDeFacturaEmitida(id);
            return View(model);
        }
    }
}
