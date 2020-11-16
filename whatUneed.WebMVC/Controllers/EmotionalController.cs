using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whatUneed.Models.Emotional;

namespace whatUneed.WebMVC.Controllers
{
    [Authorize]
    public class EmotionalController : Controller
    {
        // GET: Emotional
        public ActionResult Index()
        {
            var model = new EmotionalListItem[0];
            return View(model);
        }

        //GET: Emotional/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}
