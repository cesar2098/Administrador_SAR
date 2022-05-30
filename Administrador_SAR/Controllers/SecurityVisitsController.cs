using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Administrador_SAR.DBContext;

namespace Administrador_SAR.Views
{
    public class SecurityVisitsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: SecurityVisits
        public ActionResult Index()
        {
            return View(db.SecurityVisit.ToList());
        }

        // GET: SecurityVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityVisit securityVisit = db.SecurityVisit.Find(id);

            if (securityVisit == null)
            {
                return HttpNotFound();
            }
            return View(securityVisit);
        }

        // GET: SecurityVisits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityVisits/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsActive")] SecurityVisit securityVisit)
        {
            if (ModelState.IsValid)
            {
                db.SecurityVisit.Add(securityVisit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(securityVisit);
        }

        // GET: SecurityVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityVisit securityVisit = db.SecurityVisit.Find(id);
            if (securityVisit == null)
            {
                return HttpNotFound();
            }
            return View(securityVisit);
        }

        // POST: SecurityVisits/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsActive")] SecurityVisit securityVisit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityVisit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(securityVisit);
        }

        // GET: SecurityVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityVisit securityVisit = db.SecurityVisit.Find(id);
            if (securityVisit == null)
            {
                return HttpNotFound();
            }
            return View(securityVisit);
        }

        // POST: SecurityVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecurityVisit securityVisit = db.SecurityVisit.Find(id);
            db.SecurityVisit.Remove(securityVisit);
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
