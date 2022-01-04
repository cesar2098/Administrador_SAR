using Administrador_SAR.Models;
using Administrador_SAR.Services;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Administrador_SAR.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginServices _service;
        public LoginController()
        {
            _service = new LoginServices();
        }
         
        [HttpGet]
        public ActionResult login()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Title = "Iniciar Sesion";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> login(LoginModelRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Hacer validaciones
            var result = await  _service.SigIn(model);
            if (result != null)
            {
                //Agrgar usuario a session
                Session["UserId"] = result.UserId;
                Session["UserName"] = result.FirstName;
                Session["Rol"] = result.RolId;
                return RedirectToAction("Dashboard", "Home");
            }

            ModelState.AddModelError("NotFound", "Usuario o Contraseña incorrectos");

            return View(model);
            
        }

        public ActionResult register()
        {

            return View();
        }

    }
}
