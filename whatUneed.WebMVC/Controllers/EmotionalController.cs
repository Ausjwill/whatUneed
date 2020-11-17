using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using whatUneed.Data;
using whatUneed.Models.Emotional;
using whatUneed.Services;

namespace whatUneed.WebMVC.Controllers
{
    [Authorize]
    public class EmotionalController : Controller
    {
        // GET: Emotional
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmotionalService(userId);
            var model = service.GetEmotionals();

            return View(model);
        }

        //GET: Emotional/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmotionalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEmotionalService();

            if (service.CreateEmotional(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEmotionalService();
            var model = svc.GetEmotionalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEmotionalService();
            var detail = service.GetEmotionalById(id);
            var model =
                new EmotionalEdit
                {
                    EmotionalId = detail.EmotionalId,
                    CategoryType = detail.CategoryType,
                    Title = detail.Title,
                    Content = detail.Content
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmotionalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EmotionalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEmotionalService();

            if (service.UpdateEmotional(model))
            {
                TempData["SaveResult"] = "Your entry was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your entry could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEmotionalService();
            var model = svc.GetEmotionalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEmotionalService();

            service.DeleteEmotional(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }

        private EmotionalService CreateEmotionalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmotionalService(userId);
            return service;
        }
    }
}
