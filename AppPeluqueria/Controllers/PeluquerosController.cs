using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPeluqueria.Models.BD;
using AppPeluqueria.Models.Peluqueros;
using AutoMapper;

namespace AppPeluqueria.Controllers
{
    public class PeluquerosController : Controller
    {
        private BDPeluqueriaEntities2 db = new BDPeluqueriaEntities2();

        // GET: Peluqueros
        public ActionResult Index()
        {
            var peluqueros = db.Peluqueros;
            var modelos = Mapper.Map<IEnumerable<Peluqueros>, IEnumerable<InfoPeluquero>>(peluqueros);

            return View(modelos);
        }

        // GET: Peluqueros/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peluqueros peluqueros = db.Peluqueros.Find(id);
            if (peluqueros == null)
            {
                return HttpNotFound();
            }
            return View(peluqueros);
        }

        // GET: Peluqueros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peluqueros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dni_Pel,nombre_Pel,apell_Pel,dir_Pel")] Peluqueros peluqueros)
        {
            if (ModelState.IsValid)
            {
                db.Peluqueros.Add(peluqueros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peluqueros);
        }

        // GET: Peluqueros/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peluqueros peluqueros = db.Peluqueros.Find(id);
            if (peluqueros == null)
            {
                return HttpNotFound();
            }
            return View(peluqueros);
        }

        // POST: Peluqueros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dni_Pel,nombre_Pel,apell_Pel,dir_Pel")] Peluqueros peluqueros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peluqueros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peluqueros);
        }

        // GET: Peluqueros/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peluqueros peluqueros = db.Peluqueros.Find(id);
            if (peluqueros == null)
            {
                return HttpNotFound();
            }
            return View(peluqueros);
        }

        // POST: Peluqueros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Peluqueros peluqueros = db.Peluqueros.Find(id);
            db.Peluqueros.Remove(peluqueros);
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
