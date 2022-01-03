using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Administrador_SAR.DBContext;

namespace Administrador_SAR.Controllers
{
    public class FactorsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: Factors
        public ActionResult Index()
        {
            return View(db.Factors.ToList());
        }

        // GET: Factors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factors factors = db.Factors.Find(id);
            if (factors == null)
            {
                return HttpNotFound();
            }
            return View(factors);
        }

        // GET: Factors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Factors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsActive")] Factors factors)
        {
            if (ModelState.IsValid)
            {
                db.Factors.Add(factors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(factors);
        }

        // GET: Factors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factors factors = db.Factors.Find(id);
            if (factors == null)
            {
                return HttpNotFound();
            }
            return View(factors);
        }

        // POST: Factors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsActive")] Factors factors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(factors);
        }

        // GET: Factors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factors factors = db.Factors.Find(id);
            if (factors == null)
            {
                return HttpNotFound();
            }
            return View(factors);
        }

        // POST: Factors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factors factors = db.Factors.Find(id);
            db.Factors.Remove(factors);
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
