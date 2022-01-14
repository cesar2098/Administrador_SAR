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
    public class VisitManagersReportsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: VisitManagersReports
        public ActionResult Index()
        {
            var visitManagersCommitmentReport = db.VisitManagersCommitmentReport.Include(v => v.Accounts).Include(v => v.WorkPlaces).ToList();
            foreach (var item in visitManagersCommitmentReport)
            {
                item.VisitManagersCommitmentResults = db.VisitManagersCommitmentResults.Where(x => x.ReportId == item.Id).ToList();
            }
            return View(visitManagersCommitmentReport);
        }

        // GET: VisitManagersReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitManagersCommitmentReport visitManagersCommitmentReport = db.VisitManagersCommitmentReport.Find(id);
            if (visitManagersCommitmentReport == null)
            {
                return HttpNotFound();
            }
            return View(visitManagersCommitmentReport);
        }

        // GET: VisitManagersReports/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name");
            return View();
        }

        // POST: VisitManagersReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,WorkPlaceId,CreateDate,CreateTime")] VisitManagersCommitmentReport visitManagersCommitmentReport)
        {
            if (ModelState.IsValid)
            {
                db.VisitManagersCommitmentReport.Add(visitManagersCommitmentReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitManagersCommitmentReport.AccountId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitManagersCommitmentReport.WorkPlaceId);
            return View(visitManagersCommitmentReport);
        }

        // GET: VisitManagersReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitManagersCommitmentReport visitManagersCommitmentReport = db.VisitManagersCommitmentReport.Find(id);
            if (visitManagersCommitmentReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitManagersCommitmentReport.AccountId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitManagersCommitmentReport.WorkPlaceId);
            return View(visitManagersCommitmentReport);
        }

        // POST: VisitManagersReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,WorkPlaceId,CreateDate,CreateTime")] VisitManagersCommitmentReport visitManagersCommitmentReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitManagersCommitmentReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitManagersCommitmentReport.AccountId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitManagersCommitmentReport.WorkPlaceId);
            return View(visitManagersCommitmentReport);
        }

        // GET: VisitManagersReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitManagersCommitmentReport visitManagersCommitmentReport = db.VisitManagersCommitmentReport.Find(id);
            if (visitManagersCommitmentReport == null)
            {
                return HttpNotFound();
            }
            return View(visitManagersCommitmentReport);
        }

        // POST: VisitManagersReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitManagersCommitmentReport visitManagersCommitmentReport = db.VisitManagersCommitmentReport.Find(id);
            db.VisitManagersCommitmentReport.Remove(visitManagersCommitmentReport);
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
