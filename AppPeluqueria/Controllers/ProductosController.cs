using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppPeluqueria.Models.BD;
using AppPeluqueria.Models.Productos;
using AutoMapper;

namespace AppPeluqueria.Controllers
{
    public class ProductosController : Controller
    {
        private BDPeluqueriaEntities2 db = new BDPeluqueriaEntities2();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.Productos.Include(c => c.Casa_Comerc);
            var modelos = Mapper.Map<IEnumerable<Productos>, IEnumerable<InfoProducto>>(productos);

            //var prod = new Productos ();
            //var resprod = new Res_Prod();

            //if (!prod.cantidad.ToString().Equals(resprod.cantidad_Reservada.ToString()))
            //{
            //    prod.cantidad = resprod.cantidad_Reservada;
            //}

            return View(modelos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.id_Casa = new SelectList(db.Casa_Comerc, "id_Casa", "nombre_Casa");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_Prod,nombre_Prod,cantidad,id_Casa")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_Casa = new SelectList(db.Casa_Comerc, "id_Casa", "nombre_Casa", productos.id_Casa);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_Casa = new SelectList(db.Casa_Comerc, "id_Casa", "nombre_Casa", productos.id_Casa);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Prod,nombre_Prod,cantidad,id_Casa")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_Casa = new SelectList(db.Casa_Comerc, "id_Casa", "nombre_Casa", productos.id_Casa);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = db.Productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Productos productos = db.Productos.Find(id);
            db.Productos.Remove(productos);
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
