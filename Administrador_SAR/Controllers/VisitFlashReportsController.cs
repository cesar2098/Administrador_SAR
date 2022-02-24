using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Administrador_SAR.DBContext;
using Administrador_SAR.Models.VisitFlash;
using Administrador_SAR.Services;
using AutoMapper;

namespace Administrador_SAR.Controllers
{
    public class VisitFlashReportsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();
        private FlashReportService _reportService = new FlashReportService();

        // GET: VisitFlashReports
        public ActionResult Index()
        {
            var visitFlashReports = db.VisitFlashReports.Include(v => v.Accounts).Include(v => v.WorkPlaces).ToList();
            var viewModel = Mapper.Map<IList<VisitFlashViewModelResponse>>(visitFlashReports);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(viewModel);
        }

        public JsonResult GetReports(DateTime startDate, DateTime endDate, int workPlaceId = 0)
        {
            if (startDate == null) startDate = DateTime.Today;
            if (endDate == null) endDate = DateTime.Today.AddDays(-7);
            var reports = db.VisitFlashReports
                            .Include(r => r.Accounts)
                            .Include(r => r.WorkPlaces).OrderByDescending(x => x.CreatedDate)
                            .Where(x => x.WorkPlaceId == workPlaceId && x.CreatedDate >= startDate && x.CreatedDate <= endDate)
                            .ToList();

            var viewModel = Mapper.Map<IList<VisitFlashViewModelResponse>>(reports);
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetWorkPlacesByCountry(int id)
        {
            var workPlaces = db.WorkPlaces.Where(w => w.CountryId == id).ToList();
            return Json(workPlaces, JsonRequestBehavior.AllowGet);
        }

        // GET: VisitFlashReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitFlashReports visitFlashReports = db.VisitFlashReports.Find(id);
            if (visitFlashReports == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<VisitFlashViewModelResponse>(visitFlashReports);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> CreatePDF(int id)
        {
            byte[] result = await _reportService.getReport(id);
            var output = new FileContentResult(result, "application/octet-stream");
            output.FileDownloadName = "FlashReport.pdf";
            return output;
        }

        // GET: VisitFlashReports/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name");
            return View();
        }

        // POST: VisitFlashReports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Bu,Name,LastName,BirthDay,Antiquity,TypeEmployee,CategoryEmployee,Gender,Nationality,Position,AccidentType,Schedule,AccidentDate,AccidentTime,WorkPlaceId,DevelopedActivity,DirectCause,AffectedBodyPart,NatureOfInjury,IsSeriousAccident,CouldBeSeriousAccident,Description,CreatedDate,CreatedTime,AccountId,FlashAlertType")] VisitFlashReports visitFlashReports)
        {
            if (ModelState.IsValid)
            {
                db.VisitFlashReports.Add(visitFlashReports);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitFlashReports.AccountId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitFlashReports.WorkPlaceId);
            return View(visitFlashReports);
        }

        // GET: VisitFlashReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitFlashReports visitFlashReports = db.VisitFlashReports.Find(id);
            if (visitFlashReports == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitFlashReports.AccountId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitFlashReports.WorkPlaceId);
            return View(visitFlashReports);
        }

        // POST: VisitFlashReports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Bu,Name,LastName,BirthDay,Antiquity,TypeEmployee,CategoryEmployee,Gender,Nationality,Position,AccidentType,Schedule,AccidentDate,AccidentTime,WorkPlaceId,DevelopedActivity,DirectCause,AffectedBodyPart,NatureOfInjury,IsSeriousAccident,CouldBeSeriousAccident,Description,CreatedDate,CreatedTime,AccountId,FlashAlertType")] VisitFlashReports visitFlashReports)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitFlashReports).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "FirstName", visitFlashReports.AccountId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", visitFlashReports.WorkPlaceId);
            return View(visitFlashReports);
        }

        // GET: VisitFlashReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitFlashReports visitFlashReports = db.VisitFlashReports.Find(id);
            if (visitFlashReports == null)
            {
                return HttpNotFound();
            }
            return View(visitFlashReports);
        }

        // POST: VisitFlashReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitFlashReports visitFlashReports = db.VisitFlashReports.Find(id);
            db.VisitFlashReports.Remove(visitFlashReports);
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
