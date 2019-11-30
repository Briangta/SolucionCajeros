using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cajeros.Aplicacion;

namespace Cajeros.Web.Controllers
{
    public class RutasController : Controller
    {
        [AccesoSeguridad()]
        public ActionResult Index()
        {
            return View();
        }

    }
}