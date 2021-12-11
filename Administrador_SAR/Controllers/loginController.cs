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
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> login(LoginModelRequest model)
        {
            //Hacer validaciones
            var result = await  _service.SigIn(model);
            if (result == null)
            {
                //Agrgar usuario a session
                Session["UserId"] = 1;
                Session["UserName"] = "Daniel";
                return RedirectToAction("Dashboard", "Home");
            }

            return View(model);
            
        }

        public ActionResult register()
        {

            return View();
        }

    }
}
