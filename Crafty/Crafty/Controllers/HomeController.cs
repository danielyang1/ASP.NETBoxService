using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crafty.Controllers
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
            ViewBag.Message = "We want your feedback!";

            return View();
        }

        public ActionResult Survey()
        {
            ViewBag.Message = "Survey page.";

            return View();
        }

        public ActionResult Products()
        {
            ViewBag.Message = "Products page.";

            return View();
        }
    }
}