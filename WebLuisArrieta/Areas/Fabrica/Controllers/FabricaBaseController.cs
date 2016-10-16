using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using WebLuisArrieta.Filters;
using WebLuisArrieta.Repositorio;

namespace WebLuisArrieta.Areas.Fabrica.Controllers
{
    [Authorize]
   // [ExceptionControl]
    public class FabricaBaseController<T> : Controller
        where T : class
        {
        protected IRepositorio<T> _repositorio;
        public FabricaBaseController()
        {
            _repositorio = new BaseRepositorio<T>();
        }
                   
        }
}