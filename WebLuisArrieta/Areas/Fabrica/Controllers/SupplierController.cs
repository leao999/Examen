﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLuisArrieta.Model;

namespace WebLuisArrieta.Areas.Fabrica.Controllers
{
    public class SupplierController : FabricaBaseController<Supplier>
    // public class ClienteController : Controller
    {
        // GET: Cliente
        //  private WebLuisArrietaRepositorio _repositorio = new WebLuisArrietaRepositorio();
        public ActionResult Index()
        {
            //return View(_customer.)
            return View(_repositorio.GetList().Take(15));
        }
    }
}