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
    public class SecurityVisitQuestionsReportsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: SecurityVisitQuestionsReports
        public ActionResult Index()
        {
            var securityVisitQuestionsReport = db.SecurityVisitQuestionsReport.Include(s => s.VisitSecurityReport);
            return View(securityVisitQuestionsReport.ToList());
        }

        // GET: SecurityVisitQuestionsReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityVisitQuestionsReport securityVisitQuestionsReport = db.SecurityVisitQuestionsReport.Find(id);
            if (securityVisitQuestionsReport == null)
            {
                return HttpNotFound();
            }
            return View(securityVisitQuestionsReport);
        }

        // GET: SecurityVisitQuestionsReports/Create
        public ActionResult Create()
        {


            ViewBag.ReportId = new SelectList(db.Reports, "Id", "Description");
            return View();
        }

        // POST: SecurityVisitQuestionsReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReportId,Description,Si,No,Np,Comment,InitialDate,RealDate")] SecurityVisitQuestionsReport securityVisitQuestionsReport)
        {
            if (ModelState.IsValid)
            {


                db.SecurityVisitQuestionsReport.Add(securityVisitQuestionsReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReportId = new SelectList(db.VisitSecurityReport, "Id", "Id", securityVisitQuestionsReport.ReportId);
            return View(securityVisitQuestionsReport);
        }

        // GET: SecurityVisitQuestionsReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityVisitQuestionsReport securityVisitQuestionsReport = db.SecurityVisitQuestionsReport.Find(id);
            if (securityVisitQuestionsReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportId = new SelectList(db.VisitSecurityReport, "Id", "Id", securityVisitQuestionsReport.ReportId);
            return View(securityVisitQuestionsReport);
        }

        // POST: SecurityVisitQuestionsReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReportId,Description,Si,No,Np,Comment,InitialDate,RealDate")] SecurityVisitQuestionsReport securityVisitQuestionsReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(securityVisitQuestionsReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReportId = new SelectList(db.VisitSecurityReport, "Id", "Id", securityVisitQuestionsReport.ReportId);
            return View(securityVisitQuestionsReport);
        }

        // GET: SecurityVisitQuestionsReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecurityVisitQuestionsReport securityVisitQuestionsReport = db.SecurityVisitQuestionsReport.Find(id);
            if (securityVisitQuestionsReport == null)
            {
                return HttpNotFound();
            }
            return View(securityVisitQuestionsReport);
        }

        // POST: SecurityVisitQuestionsReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecurityVisitQuestionsReport securityVisitQuestionsReport = db.SecurityVisitQuestionsReport.Find(id);
            db.SecurityVisitQuestionsReport.Remove(securityVisitQuestionsReport);
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
