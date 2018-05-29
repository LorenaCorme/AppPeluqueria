using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPeluqueria.Models.BD;
using AppPeluqueria.Models.Reservas;
using AutoMapper;

namespace AppPeluqueria.Controllers
{
    public class ReservasController : Controller
    {
        private BDPeluqueriaEntities2 db = new BDPeluqueriaEntities2();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Clientes).Include(r => r.Peluqueros);
            var modelos = Mapper.Map<IEnumerable<Reservas>, IEnumerable<InfoReserva>>(reservas);

            return View(modelos);
        }

        // GET: Reservas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli");
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel");
            ViewBag.id_Prod = new SelectList(db.Productos, "id_Prod", "nombre_Prod");
            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "num_Res,dni_Cli,dni_Pel")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reservas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli", reservas.dni_Cli);
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel", reservas.dni_Pel);
            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli", reservas.dni_Cli);
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel", reservas.dni_Pel);
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "num_Res,dni_Cli,dni_Pel")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dni_Cli = new SelectList(db.Clientes, "dni_Cli", "nombre_Cli", reservas.dni_Cli);
            ViewBag.dni_Pel = new SelectList(db.Peluqueros, "dni_Pel", "nombre_Pel", reservas.dni_Pel);
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Reservas reservas = db.Reservas.Find(id);
            db.Reservas.Remove(reservas);
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
