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
    public class QuestionSecurityVisitsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: QuestionSecurityVisits
        public ActionResult Index()
        {
            var questionSecurityVisit = db.QuestionSecurityVisit.Include(q => q.SecurityVisit);
            return View(questionSecurityVisit.ToList());
        }

        // GET: QuestionSecurityVisits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSecurityVisit questionSecurityVisit = db.QuestionSecurityVisit.Find(id);
            
            if (questionSecurityVisit == null)
            {
                return HttpNotFound();
            }
            return View(questionSecurityVisit);
        }

        // GET: QuestionSecurityVisits/Create
        public ActionResult Create(int id)
        {
            var securityVisit = db.SecurityVisit.FirstOrDefault(x => x.Id == id);
            ViewBag.IdSecurityVisit = new SelectList(db.SecurityVisit, "Id", "Description", securityVisit);
            return View();
        }

        // POST: QuestionSecurityVisits/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSecurityVisit,Description,IsActive")] QuestionSecurityVisit questionSecurityVisit)
        {
            if (ModelState.IsValid)
            {
                db.QuestionSecurityVisit.Add(questionSecurityVisit);
                db.SaveChanges();
                return RedirectToAction("Details", "SecurityVisits", new { id = questionSecurityVisit.IdSecurityVisit });
            }

            ViewBag.IdSecurityVisit = new SelectList(db.SecurityVisit, "Id", "Description", questionSecurityVisit.IdSecurityVisit);
            return View(questionSecurityVisit);
        }

        // GET: QuestionSecurityVisits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSecurityVisit questionSecurityVisit = db.QuestionSecurityVisit.Find(id);
            if (questionSecurityVisit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSecurityVisit = new SelectList(db.SecurityVisit, "Id", "Description", questionSecurityVisit.IdSecurityVisit);
            return View(questionSecurityVisit);
        }

        // POST: QuestionSecurityVisits/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSecurityVisit,Description,IsActive")] QuestionSecurityVisit questionSecurityVisit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionSecurityVisit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "SecurityVisits",new {id = questionSecurityVisit.IdSecurityVisit});
            }
            ViewBag.IdSecurityVisit = new SelectList(db.SecurityVisit, "Id", "Description", questionSecurityVisit.IdSecurityVisit);
            return View(questionSecurityVisit);
        }

        // GET: QuestionSecurityVisits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionSecurityVisit questionSecurityVisit = db.QuestionSecurityVisit.Find(id);
            if (questionSecurityVisit == null)
            {
                return HttpNotFound();
            }
            return View(questionSecurityVisit);
        }

        // POST: QuestionSecurityVisits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionSecurityVisit questionSecurityVisit = db.QuestionSecurityVisit.Find(id);
            db.QuestionSecurityVisit.Remove(questionSecurityVisit);
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
