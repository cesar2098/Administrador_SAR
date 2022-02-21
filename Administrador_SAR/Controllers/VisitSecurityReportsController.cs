using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Administrador_SAR.DBContext;

namespace Administrador_SAR.Controllers
{
    public class VisitSecurityReportsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: VisitSecurityReports
        public ActionResult Index()
        {
            var visitSecurityReport = db.VisitSecurityReport.Include(v => v.Accounts).Include(v => v.SecurityVisit).Include(v => v.WorkPlaces).ToList();
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(visitSecurityReport);
        }

        public JsonResult GetReports(DateTime startDate, DateTime endDate, int workPlaceId = 0)
        {
            if (startDate == null) startDate = DateTime.Today;
            if (endDate == null) endDate = DateTime.Today.AddDays(-7);
            var reports = db.VisitSecurityReport.Include(v => v.Accounts).Include(v => v.SecurityVisit).Include(v => v.WorkPlaces)
                            .Where(x => x.WorkPlaceId == workPlaceId && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();

            foreach (var item in reports)
            {
                foreach (var item2 in item.SecurityVisitQuestionsReport)
                {
                    item2.VisitSecurityReport = null;
                }
            }
            return Json(reports, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetWorkPlacesByCountry(int id)
        {
            var workPlaces = db.WorkPlaces.Where(w => w.CountryId == id).ToList();
            return Json(workPlaces, JsonRequestBehavior.AllowGet);
        }

        // GET: VisitSecurityReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var visitSecurityReport = db.VisitSecurityReport.Include(v => v.Accounts).Include(v => v.SecurityVisit).Include(v => v.WorkPlaces)
                                        .Where(x => x.Id == id).FirstOrDefault();
            if (visitSecurityReport == null)
            {
                return HttpNotFound();
            }

            visitSecurityReport.SecurityVisitQuestionsReport = db.SecurityVisitQuestionsReport.Where(x => x.ReportId == id).ToList();
            return View(visitSecurityReport);
        }

        // GET: VisitSecurityReports/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.SecurityVisitId = new SelectList(db.SecurityVisit, "Id", "Description");
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name");
            return View();
        }

        // POST: VisitSecurityReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,CreatedDate,CreatedTime,WorkPlaceId,SecurityVisitId")] VisitSecurityReport visitSecurityReport)
        {
            if (ModelState.IsValid)
            {
                db.VisitSecurityReport.Add(visitSecurityReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitSecurityReport.AccountId);
            ViewBag.SecurityVisitId = new SelectList(db.SecurityVisit, "Id", "Description", visitSecurityReport.SecurityVisitId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitSecurityReport.WorkPlaceId);
            return View(visitSecurityReport);
        }

        // GET: VisitSecurityReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitSecurityReport visitSecurityReport = db.VisitSecurityReport.Find(id);
            if (visitSecurityReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitSecurityReport.AccountId);
            ViewBag.SecurityVisitId = new SelectList(db.SecurityVisit, "Id", "Description", visitSecurityReport.SecurityVisitId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitSecurityReport.WorkPlaceId);
            return View(visitSecurityReport);
        }

        // POST: VisitSecurityReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,CreatedDate,CreatedTime,WorkPlaceId,SecurityVisitId")] VisitSecurityReport visitSecurityReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitSecurityReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitSecurityReport.AccountId);
            ViewBag.SecurityVisitId = new SelectList(db.SecurityVisit, "Id", "Description", visitSecurityReport.SecurityVisitId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitSecurityReport.WorkPlaceId);
            return View(visitSecurityReport);
        }

        // GET: VisitSecurityReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitSecurityReport visitSecurityReport = db.VisitSecurityReport.Find(id);
            if (visitSecurityReport == null)
            {
                return HttpNotFound();
            }
            return View(visitSecurityReport);
        }

        // POST: VisitSecurityReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitSecurityReport visitSecurityReport = db.VisitSecurityReport.Find(id);
            db.VisitSecurityReport.Remove(visitSecurityReport);
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
