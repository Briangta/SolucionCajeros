using System;
using System.Collections.Generic;
using System.Configuration;
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
            ViewBag.Url = ConfigurationManager.AppSettings["urlRest"];
            return View();
        }

        public ActionResult MapaCalor()
        {
            return View();
        }

        public ActionResult AgregarUnEvento()
        {
            List<SelectListItem> items = new List<SelectListItem> { new SelectListItem { Text = "Todas", Value = "1" },
                new SelectListItem { Text = "Occidente", Value = "1" },
                new SelectListItem { Text = "Norte", Value = "1" },
                new SelectListItem { Text = "Sur", Value = "1" },
                new SelectListItem { Text = "Centro", Value = "1" } };
            ViewBag.Zona = new SelectList(items, "Value", "Text");

            List<SelectListItem> itemsTipo = new List<SelectListItem> { new SelectListItem { Text = "Fuera de Servicio", Value = "1" },
                new SelectListItem { Text = "Aumento", Value = "1" } };

            ViewBag.Zona = new SelectList(items, "Value", "Text");
            ViewBag.Tipo = new SelectList(itemsTipo, "Value", "Text");
            return View();
        }
    }
}