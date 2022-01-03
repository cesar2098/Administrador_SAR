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
    public class KillersController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: Killers
        public ActionResult Index()
        {
            return View(db.Killers.ToList());
        }

        // GET: Killers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Killers killers = db.Killers.Find(id);
            if (killers == null)
            {
                return HttpNotFound();
            }
            return View(killers);
        }

        // GET: Killers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Killers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IsActive")] Killers killers)
        {
            if (ModelState.IsValid)
            {
                db.Killers.Add(killers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(killers);
        }

        // GET: Killers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Killers killers = db.Killers.Find(id);
            if (killers == null)
            {
                return HttpNotFound();
            }
            return View(killers);
        }

        // POST: Killers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsActive")] Killers killers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(killers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(killers);
        }

        // GET: Killers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Killers killers = db.Killers.Find(id);
            if (killers == null)
            {
                return HttpNotFound();
            }
            return View(killers);
        }

        // POST: Killers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Killers killers = db.Killers.Find(id);
            db.Killers.Remove(killers);
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
