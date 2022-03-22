using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Administrador_SAR.DBContext;
using Administrador_SAR.Models.Reports;
using Administrador_SAR.Services;
using AutoMapper;

namespace Administrador_SAR.Controllers
{
    public class ReportsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();
        private ReportService _reportService = new ReportService();

        // GET: Reports
        public ActionResult Index(int workPlaceId = 0)
        {
            var reports = db.Reports
                            .Include(r => r.Accounts)
                            .Include(r => r.Categories)
                            .Include(r => r.Factors)
                            .Include(r => r.Killers)
                            .Include(r => r.Situations)
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate).ToList();
            if (workPlaceId != 0)
            {
                reports = reports.Where(x => x.WorkPlaceId == workPlaceId).ToList();
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            var result = Mapper.Map<IList<ReportResponseViewModel>>(reports); 
            return View(result);
        }

        public JsonResult GetReports(DateTime startDate, DateTime endDate, int workPlaceId = 0)
        {
            if (startDate == null) startDate = DateTime.Today.AddDays(-7); 
            if (endDate == null) endDate = DateTime.Today;
            var reports = db.Reports
                            .Include(r => r.Accounts)
                            .Include(r => r.Categories)
                            .Include(r => r.Factors)
                            .Include(r => r.Killers)
                            .Include(r => r.Situations)
                            .Include(r => r.StatusReports)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x =>  x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();
            
            if (workPlaceId != 0)
            {
                reports = reports.Where(x => x.WorkPlaceId == workPlaceId).ToList();
            }

            var viewModel = Mapper.Map<IList<ReportResponseViewModel>>(reports);
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetWorkPlacesByCountry(int id)
        {
            var workPlaces = db.WorkPlaces.Where(w => w.CountryId == id).ToList();
            return Json(workPlaces, JsonRequestBehavior.AllowGet);
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reports reports  = db.Reports.Include(r => r.Accounts)
                                .Include(r => r.Categories)
                                .Include(r => r.Factors)
                                .Include(r => r.Killers)
                                .Include(r => r.Situations)
                                .Include(r => r.StatusReports)
                                .Include(r => r.Evidences)
                                .Include(r => r.WorkPlaces).FirstOrDefault(x => x.Id == id);

            if (reports == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<ReportResponseViewModel>(reports);
            return View(viewModel);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description");
            ViewBag.FatorId = new SelectList(db.Factors, "Id", "Description");
            ViewBag.KillerId = new SelectList(db.Killers, "Id", "Name");
            ViewBag.SituationId = new SelectList(db.Situations, "Id", "Description");
            ViewBag.StatusId = new SelectList(db.StatusReports, "Id", "Description");
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name");
            return View();
        }

        // POST: Reports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,CreatedDate,CreatedTime,Description,StatusId,CategoryId,WorkPlaceId,SituationId,Comment,KillerId,FatorId,CorrectiveComment")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                db.Reports.Add(reports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", reports.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description", reports.CategoryId);
            ViewBag.FatorId = new SelectList(db.Factors, "Id", "Description", reports.FatorId);
            ViewBag.KillerId = new SelectList(db.Killers, "Id", "Name", reports.KillerId);
            ViewBag.SituationId = new SelectList(db.Situations, "Id", "Description", reports.SituationId);
            ViewBag.StatusId = new SelectList(db.StatusReports, "Id", "Description", reports.StatusId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", reports.WorkPlaceId);
            return View(reports);
        }

        [HttpGet]
        public async Task<ActionResult> CreatePDF(int id)
        {          
            byte [] result = await _reportService.getReport(id);
            var output = new FileContentResult(result, "application/octet-stream");
            output.FileDownloadName = "download.pdf";
            return output;
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reports reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", reports.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description", reports.CategoryId);
            ViewBag.FatorId = new SelectList(db.Factors, "Id", "Description", reports.FatorId);
            ViewBag.KillerId = new SelectList(db.Killers, "Id", "Name", reports.KillerId);
            ViewBag.SituationId = new SelectList(db.Situations, "Id", "Description", reports.SituationId);
            ViewBag.StatusId = new SelectList(db.StatusReports, "Id", "Description", reports.StatusId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", reports.WorkPlaceId);
            return View(reports);
        }

        // POST: Reports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,CreatedDate,CreatedTime,Description,StatusId,CategoryId,WorkPlaceId,SituationId,Comment,KillerId,FatorId,CorrectiveComment")] Reports reports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", reports.UserId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Description", reports.CategoryId);
            ViewBag.FatorId = new SelectList(db.Factors, "Id", "Description", reports.FatorId);
            ViewBag.KillerId = new SelectList(db.Killers, "Id", "Name", reports.KillerId);
            ViewBag.SituationId = new SelectList(db.Situations, "Id", "Description", reports.SituationId);
            ViewBag.StatusId = new SelectList(db.StatusReports, "Id", "Description", reports.StatusId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", reports.WorkPlaceId);
            return View(reports);
        }

        // GET: Reports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reports reports = db.Reports.Find(id);
            if (reports == null)
            {
                return HttpNotFound();
            }
            return View(reports);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reports reports = db.Reports.Find(id);
            db.Reports.Remove(reports);
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
