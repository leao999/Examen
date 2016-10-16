using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLuisArrieta.Repositorio;
using WebLuisArrieta.Model;


namespace WebLuisArrieta.Areas.Fabrica.Controllers
{
    public class CustomerController : FabricaBaseController<Customer>
   // public class ClienteController : Controller
    {
        // GET: Cliente
      //  private WebLuisArrietaRepositorio _repositorio = new WebLuisArrietaRepositorio();
        public ActionResult Index()
        {
            //return View(_customer.)
            return View(_repositorio.GetList().Take(15));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            //customer.Id = Guid.
           // customer.Order = new Order
            {
                //Id = customer.Id
           //     Customer = customer.LastName
            };
            _repositorio.Agregar(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var customer = _repositorio.GetById(x => x.Id == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Editar(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repositorio.Actualizar(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Borrar(int id)
        {
            var person = _repositorio.GetById(x => x.Id == id);
            if (person == null) return RedirectToAction("Index");
            return View(person);
        }

        [HttpPost]
        public ActionResult Borrar(Customer customer)
        {
            customer = _repositorio.GetById(x => x.Id == customer.Id);
            _repositorio.Borrar(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Detailles(int id)
        {
            var customer = _repositorio.GetById(x => x.Id == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }
    }
}