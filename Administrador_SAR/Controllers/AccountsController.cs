using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using BC = BCrypt.Net.BCrypt;
using Administrador_SAR.DBContext;
using AutoMapper;
using Administrador_SAR.Models.Account;

namespace Administrador_SAR.Controllers
{
    public class AccountsController : Controller
    {
        private RSDBEntities db = new RSDBEntities();

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Countries);
            var viewModel = Mapper.Map<IList<AccountResponseViewModel>>(accounts);
            foreach (var item in viewModel)
            {
                if (item.Gender.Equals(0))
                    item.GenderDescription = "HOMBRE";
                else
                    item.GenderDescription = "MUJER";

                if (item.IsActive)
                    item.StatusDescription = "ACTIVO";
                else
                    item.StatusDescription = "INACTIVO";
            }
            return View(viewModel);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map<AccountResponseViewModel>(accounts);
            return View(viewModel);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            List<GenderModel> genders = new List<GenderModel>();
            List<RolModel> rols = new List<RolModel>();
            genders.Add(new GenderModel() { Id = 0, Description = "HOMBRE" });
            genders.Add(new GenderModel() { Id = 1, Description = "MUJER" });

            rols.Add(new RolModel() { Id = 0, Description = "Administrador" });
            rols.Add(new RolModel() { Id = 1, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 2, Description = "Default" });

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.Gender = new SelectList(genders, "Id", "Description");
            ViewBag.Roles = new SelectList(rols, "Id", "Description");

            return View();
        }

        // POST: Accounts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CountryId,FirstName,LastName,Gender,Email,Phone,Password,IsActive,Role,VerificationToken,Verified,ResetToken,ResetTokenExpires,PasswordReset,Created,Updated")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                accounts.Created = DateTime.Now;
                accounts.Password = BC.HashPassword("12345678");//Contraseña por defecto
                db.Accounts.Add(accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", accounts.CountryId);
            return View(accounts);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }

            List<GenderModel> genders = new List<GenderModel>();
            List<RolModel> rols = new List<RolModel>();
            genders.Add(new GenderModel() { Id = 0, Description = "HOMBRE" });
            genders.Add(new GenderModel() { Id = 1, Description = "MUJER" });

            rols.Add(new RolModel() { Id = 0, Description = "Administrador" });
            rols.Add(new RolModel() { Id = 1, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 2, Description = "Default" });

            ViewBag.Gender = new SelectList(genders, "Id", "Description", account.Gender);
            ViewBag.Roles = new SelectList(rols, "Id", "Description", account.Role);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", account.CountryId);
            return View(account);
        }

        // POST: Accounts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CountryId,FirstName,LastName,Gender,Email,Phone,Password,IsActive,Role,VerificationToken,Verified,ResetToken,ResetTokenExpires,PasswordReset,Created,Updated")] Accounts account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<GenderModel> genders = new List<GenderModel>();
            List<RolModel> rols = new List<RolModel>();
            genders.Add(new GenderModel() { Id = 0, Description = "HOMBRE" });
            genders.Add(new GenderModel() { Id = 1, Description = "MUJER" });

            rols.Add(new RolModel() { Id = 0, Description = "Administrador" });
            rols.Add(new RolModel() { Id = 1, Description = "Gerente" });
            rols.Add(new RolModel() { Id = 2, Description = "Default" });

            ViewBag.Gender = new SelectList(genders, "Id", "Description", account.Gender);
            ViewBag.Roles = new SelectList(rols, "Id", "Description", account.Role);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", account.CountryId);
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounts accounts = db.Accounts.Find(id);
            db.Accounts.Remove(accounts);
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
