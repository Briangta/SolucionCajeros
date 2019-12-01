using Cajeros.Aplicacion;
using Cajeros.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cajeros.Aplicacion.Enumeradores;

namespace Cajeros.Web.Controllers
{
    public class ReportesController : Controller
    {
        RetoEntities db = new RetoEntities();

        [AccesoSeguridad()]
        public ActionResult Index(int idReporte = 1)
        {
            if (EnumGrafico.CajeroRetiros == (EnumGrafico)idReporte)
            {
                var campos = db.Comportamiento.Include(r => r.Cajero).GroupBy(r => r.Cajero)
                    .Select(r => new
                    {
                        r.Key.Nombre,
                        Cantidad = (r.Sum(m => m.Cant50 ?? 0 * 50000)
                    + r.Sum(m => m.Cant20 ?? 0 * 20000) + r.Sum(m => m.Cant10 ?? 0 * 10000))
                    }).ToList();

                ViewBag.Y = String.Format("{0}", String.Join(",", campos.Select(r => r.Cantidad).ToArray()));
                ViewBag.YLabel = String.Format("{0}", String.Join(",", campos.Select(r => "\"" + r.Nombre + "\"").ToArray()));
                ViewBag.Titulo = "Retiros por Cajeros";
                string colores = string.Empty;
                Random rnd = new Random();
                campos.ToList().ForEach(r => colores += String.Format("\"rgba({0}, {1}, {2}, 0.72)\",", rnd.Next(256), rnd.Next(256), rnd.Next(256)).ToString());
                ViewBag.Colores = colores;
            }
            else if (EnumGrafico.FechaRetiros == (EnumGrafico)idReporte)
            {
                var campos = db.Comportamiento.Include(r => r.Cajero)
                    .GroupBy(r => r.Fecha.Value.Day)
                .Select(r => new
                {
                    r.Key,
                    Cantidad = (r.Sum(m => m.Cant50 ?? 0 * 50000)
                    + r.Sum(m => m.Cant20 ?? 0 * 20000) + r.Sum(m => m.Cant10 ?? 0 * 10000))
                }).OrderBy(r=>r.Key).ToList();

                ViewBag.Y = String.Format("{0}", String.Join(",", campos.Select(r => r.Cantidad).ToArray()));
                ViewBag.YLabel = String.Format("{0}", String.Join(",", campos.Select(r => "\"" + r.Key + "\"").ToArray()));
                ViewBag.Titulo = "Retiros por Día Mes";
                string colores = string.Empty;
                Random rnd = new Random();
                campos.ToList().ForEach(r => colores += String.Format("\"rgba({0}, {1}, {2}, 0.72)\",", rnd.Next(256), rnd.Next(256), rnd.Next(256)).ToString());
                ViewBag.Colores = colores;
            }

            ViewBag.Reporte = idReporte;
            return View();
        }
    }
}