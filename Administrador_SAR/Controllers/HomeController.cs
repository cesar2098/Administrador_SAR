using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrador_SAR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult adminProject()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }
        public ActionResult adminUser()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }

        public ActionResult adminTables()
        {
            ViewBag.Message = "Admin page.";

            return View();
        }

    }
}