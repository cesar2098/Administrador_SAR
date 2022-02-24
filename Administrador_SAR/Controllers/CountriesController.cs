using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Administrador_SAR.DBContext;
using Administrador_SAR.Services;

namespace Administrador_SAR.Controllers
{
    public class CountriesController : Controller
    {
        private readonly CountriesServices _countriesServices;
        private RSDBEntities db = new RSDBEntities();
        public CountriesController()
        {
            _countriesServices = new CountriesServices();
        }

        // GET: Countries
        public async Task<ActionResult> Index()
        {
            var result = await _countriesServices.GetCountries();
            return View(result);
        }

        //Lo mimso vas a hacer para los metodos de abajo, vas a mover la logica al servicio,
        //el controlador solo devuelve informacion, no hace validaciones ni nnada

        // GET: Countries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Llamamos al servicio
            //se coloca await porque es una funcion asincronca
            Countries result = await _countriesServices.GetCountrie((int)id);

            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CountryId,Name")] Countries countries)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(countries);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(countries);
        }

        //GET: Countries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return View(countries);
        }

       // POST: Countries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse.Para obtener
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CountryId,Name")] Countries countries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countries).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(countries);
        }

        //GET: Countries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = await db.Countries.FindAsync(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return View(countries);
        }

        //POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Countries countries = await db.Countries.FindAsync(id);
            db.Countries.Remove(countries);
            await db.SaveChangesAsync();
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
