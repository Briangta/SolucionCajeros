using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cajeros.Repositorio;

namespace Cajeros.Web.Controllers
{
    public class RutaTransportadorController : Controller
    {
        private RetoEntities db = new RetoEntities();

        // GET: RutaTransportador
        public ActionResult Index()
        {
            
            var ruta = db.Ruta.Include(r => r.Cajero);
            return View(ruta.ToList());
        }

        // GET: RutaTransportador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // GET: RutaTransportador/Create
        public ActionResult Create()
        {
            ViewBag.IdCajero = new SelectList(db.Cajero, "IdCajero", "Nombre");
            return View();
        }

        // POST: RutaTransportador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRuta,IdCajero,Fecha,Cumplido")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                db.Ruta.Add(ruta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCajero = new SelectList(db.Cajero, "IdCajero", "Nombre", ruta.IdCajero);
            return View(ruta);
        }

        // GET: RutaTransportador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCajero = new SelectList(db.Cajero, "IdCajero", "Nombre", ruta.IdCajero);
            return View(ruta);
        }

        // POST: RutaTransportador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRuta,IdCajero,Fecha,Cumplido")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ruta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCajero = new SelectList(db.Cajero, "IdCajero", "Nombre", ruta.IdCajero);
            return View(ruta);
        }

        // GET: RutaTransportador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ruta ruta = db.Ruta.Find(id);
            if (ruta == null)
            {
                return HttpNotFound();
            }
            return View(ruta);
        }

        // POST: RutaTransportador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ruta ruta = db.Ruta.Find(id);
            db.Ruta.Remove(ruta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
