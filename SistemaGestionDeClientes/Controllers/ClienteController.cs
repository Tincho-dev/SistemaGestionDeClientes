using Model.Custom;
using Model.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace SistemaGestionDeClientes.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        private readonly ClienteServices _clienteService = new ClienteServices();

        // GET: Cliente
        public ActionResult Index()
        {
            var listado = _clienteService.GetAll();

            return View(listado);
        }

        public ActionResult Buscar(string palabra)
        {
            var empleados = _clienteService.Buscar(palabra);

            Session["Palabra"] = palabra;

            return View("Index", empleados);
        }
        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            var model = _clienteService.Get(id);
            return View("Details", model);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            //ViewBag.DNI = new SelectList(_clienteService.GetAll(), "DNI", "ApyNom");
            return RedirectToAction("Create");
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                _clienteService.Create(cliente);

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _clienteService.GetEdit(id);
            return View(model);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteService.Update(cliente);
                }

                
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _clienteService.Get(id);
            return View(model);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _clienteService.Delete(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
