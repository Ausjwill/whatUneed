using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace whatUneed.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The purpose of what-U-need";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Feel free to get in touch";

            return View();
        }
    }
}
