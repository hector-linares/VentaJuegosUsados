using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VentaJuegosUsados.DB;

namespace VentaJuegosUsados.Controllers
{
    public class PlataformaController : Controller
    {
        private VentaJuegosUsadosEntities db = new VentaJuegosUsadosEntities();

        // GET: Plataformas
        public ActionResult Index()
        {
            return View(db.Plataforma.ToList());
        }

        // GET: Plataformas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // GET: Plataformas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plataformas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                db.Plataforma.Add(plataforma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plataforma);
        }

        // GET: Plataformas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // POST: Plataformas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plataforma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plataforma);
        }

        // GET: Plataformas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plataforma plataforma = db.Plataforma.Find(id);
            if (plataforma == null)
            {
                return HttpNotFound();
            }
            return View(plataforma);
        }

        // POST: Plataformas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plataforma plataforma = db.Plataforma.Find(id);
            db.Plataforma.Remove(plataforma);
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
