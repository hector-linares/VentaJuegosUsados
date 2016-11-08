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
    public class ArticulosController : Controller
    {
        private VentaJuegosUsadosEntities db = new VentaJuegosUsadosEntities();

        // GET: Articulos
        public ActionResult Index()
        {
            var articulos = db.Articulos.Include(a => a.Estado).Include(a => a.Genero).Include(a => a.Plataforma).Include(a => a.Usuarios);
            return View(articulos.ToList());
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estado, "id", "Nombre");
            ViewBag.idGenero = new SelectList(db.Genero, "id", "Nombre");
            ViewBag.idPlataforma = new SelectList(db.Plataforma, "id", "Nombre");
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,descripcion,fechaPublicacion,precio,imagenURL,idUsuario,idPlataforma,idGenero,idEstado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Articulos.Add(articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estado, "id", "Nombre", articulos.idEstado);
            ViewBag.idGenero = new SelectList(db.Genero, "id", "Nombre", articulos.idGenero);
            ViewBag.idPlataforma = new SelectList(db.Plataforma, "id", "Nombre", articulos.idPlataforma);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", articulos.idUsuario);
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estado, "id", "Nombre", articulos.idEstado);
            ViewBag.idGenero = new SelectList(db.Genero, "id", "Nombre", articulos.idGenero);
            ViewBag.idPlataforma = new SelectList(db.Plataforma, "id", "Nombre", articulos.idPlataforma);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", articulos.idUsuario);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,descripcion,fechaPublicacion,precio,imagenURL,idUsuario,idPlataforma,idGenero,idEstado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estado, "id", "Nombre", articulos.idEstado);
            ViewBag.idGenero = new SelectList(db.Genero, "id", "Nombre", articulos.idGenero);
            ViewBag.idPlataforma = new SelectList(db.Plataforma, "id", "Nombre", articulos.idPlataforma);
            ViewBag.idUsuario = new SelectList(db.Usuarios, "id", "nombre", articulos.idUsuario);
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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
