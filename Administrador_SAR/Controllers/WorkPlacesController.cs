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
    public class WorkPlacesController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: WorkPlaces
        public ActionResult Index()
        {
            var workPlaces = db.WorkPlaces.Include(w => w.Countries);
            return View(workPlaces.ToList());
        }

        // GET: WorkPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPlaces workPlaces = db.WorkPlaces.Find(id);
            if (workPlaces == null)
            {
                return HttpNotFound();
            }
            return View(workPlaces);
        }

        // GET: WorkPlaces/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        // POST: WorkPlaces/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkPlaceId,Name,Description,CreatedDate,CreatedTime,CountryId,Address,Latitude,Longitude,IsActive")] WorkPlaces workPlaces)
        {
            if (ModelState.IsValid)
            {
                db.WorkPlaces.Add(workPlaces);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", workPlaces.CountryId);
            return View(workPlaces);
        }

        // GET: WorkPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPlaces workPlaces = db.WorkPlaces.Find(id);
            if (workPlaces == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", workPlaces.CountryId);
            return View(workPlaces);
        }

        // POST: WorkPlaces/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkPlaceId,Name,Description,CreatedDate,CreatedTime,CountryId,Address,Latitude,Longitude,IsActive")] WorkPlaces workPlaces)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workPlaces).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", workPlaces.CountryId);
            return View(workPlaces);
        }

        // GET: WorkPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPlaces workPlaces = db.WorkPlaces.Find(id);
            if (workPlaces == null)
            {
                return HttpNotFound();
            }
            return View(workPlaces);
        }

        // POST: WorkPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkPlaces workPlaces = db.WorkPlaces.Find(id);
            db.WorkPlaces.Remove(workPlaces);
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
