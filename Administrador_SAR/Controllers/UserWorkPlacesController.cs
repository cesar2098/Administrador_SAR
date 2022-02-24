using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Administrador_SAR.DBContext;
using Administrador_SAR.Models.Account;
using Administrador_SAR.Models.Reports;
using Administrador_SAR.Models.UserWorkPlace;
using AutoMapper;

namespace Administrador_SAR.Controllers
{
    public class UserWorkPlacesController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: UserWorkPlaces
        public ActionResult Index()
        {
            var userWorkPlaces = db.UserWorkPlaces.Include(u => u.Accounts).Include(u => u.WorkPlaces).ToList();
            var result = Mapper.Map<IList<UserWorkPlaceResponse>>(userWorkPlaces);
            foreach (var item in result)
            {
                if (item.UserType == 0) item.Type = "Gerente";
                if (item.UserType == 1) item.Type = "Técnico";
                if (item.UserType == 2) item.Type = "Obrero";

                if (item.IsActive) item.Status = "Activo";
                if (!item.IsActive) item.Status = "Inactivo";
            }
            return View(result);
        }

        // GET: UserWorkPlaces/Details/5
        public ActionResult Details(int? id, int? workPlace)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkPlaces userWorkPlaces = db.UserWorkPlaces.FirstOrDefault(x => x.UserId == id && x.WorkPlaceId == workPlace);
            if (userWorkPlaces == null)
            {
                return HttpNotFound();
            }
            return View(userWorkPlaces);
        }

        // GET: UserWorkPlaces/Create
        public ActionResult Create()
        {
            List<RolModel> rols = new List<RolModel>();
            rols.Add(new RolModel() { Id = 0, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 1, Description = "Técnico" });
            rols.Add(new RolModel() { Id = 2, Description = "Obrero" });

            ViewBag.UserType = new SelectList(rols, "Id", "Description");
            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName");
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        public JsonResult GetWorkPlacesByCountry(int id)
        {
            var workPlaces = db.WorkPlaces.Where(w => w.CountryId == id).ToList();
            return Json(workPlaces, JsonRequestBehavior.AllowGet);
        }

        // POST: UserWorkPlaces/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkPlaceId,UserId,UserType,IsActive")] UserWorkPlaces userWorkPlaces)
        {
            List<RolModel> rols = new List<RolModel>();
            rols.Add(new RolModel() { Id = 0, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 1, Description = "Técnico" });
            rols.Add(new RolModel() { Id = 2, Description = "Obrero" });

            if (ModelState.IsValid)
            {
                var userExist = db.UserWorkPlaces.FirstOrDefault(x => x.WorkPlaceId == userWorkPlaces.WorkPlaceId && x.UserId == userWorkPlaces.UserId);
                if (userExist != null)
                {
                    

                    ModelState.AddModelError("", "El usuario ya existe dentro de este centro de trabajo");
                    ViewBag.UserType = new SelectList(rols, "Id", "Description");
                    ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", userWorkPlaces.UserId);
                    ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", userWorkPlaces.WorkPlaceId);
                    ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
                    return View(userWorkPlaces);
                }

                db.UserWorkPlaces.Add(userWorkPlaces);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

         

            ViewBag.UserType = new SelectList(rols, "Id", "Description");

            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", userWorkPlaces.UserId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", userWorkPlaces.WorkPlaceId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(userWorkPlaces);
        }

        // GET: UserWorkPlaces/Edit/5
        public ActionResult Edit(int? id, int? workPlace)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkPlaces userWorkPlaces = db.UserWorkPlaces.FirstOrDefault(x => x.UserId == id && x.WorkPlaceId == workPlace);
            if (userWorkPlaces == null)
            {
                return HttpNotFound();
            }

            List<RolModel> rols = new List<RolModel>();
            rols.Add(new RolModel() { Id = 0, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 1, Description = "Técnico" });
            rols.Add(new RolModel() { Id = 2, Description = "Obrero" });
            ViewBag.UserType = new SelectList(rols, "Id", "Description");
            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", userWorkPlaces.UserId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", userWorkPlaces.WorkPlaceId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(userWorkPlaces);
        }

        // POST: UserWorkPlaces/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkPlaceId,UserId,UserType,IsActive")] UserWorkPlaces userWorkPlaces)
        {
            List<RolModel> rols = new List<RolModel>();
            rols.Add(new RolModel() { Id = 0, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 1, Description = "Técnico" });
            rols.Add(new RolModel() { Id = 2, Description = "Obrero" });
            

            if (ModelState.IsValid)
            {
                db.Entry(userWorkPlaces).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserType = new SelectList(rols, "Id", "Description");
            ViewBag.UserId = new SelectList(db.Accounts, "Id", "FirstName", userWorkPlaces.UserId);
            ViewBag.WorkPlaceId = new SelectList(db.WorkPlaces, "WorkPlaceId", "Name", userWorkPlaces.WorkPlaceId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View(userWorkPlaces);
        }

        // GET: UserWorkPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkPlaces userWorkPlaces = db.UserWorkPlaces.Find(id);
            if (userWorkPlaces == null)
            {
                return HttpNotFound();
            }
            return View(userWorkPlaces);
        }

        // POST: UserWorkPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserWorkPlaces userWorkPlaces = db.UserWorkPlaces.Find(id);
            db.UserWorkPlaces.Remove(userWorkPlaces);
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
