using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using whatUneed.Models.Physical;
using whatUneed.Services;

namespace whatUneed.WebMVC.Controllers
{
    [Authorize]
    public class PhysicalController : Controller
    {
        // GET: Physical
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicalService(userId);
            var model = service.GetPhysicals();

            return View(model);
        }

        //GET: Physical/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhysicalCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePhysicalService();

            if (service.CreatePhysical(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");
            return View(model);
        }

        public ActionResult GetByCategory(string category)
        {
            PhysicalService physicalService = CreatePhysicalService();
            var physical = physicalService.GetPhysicalByCategory(category);

            if (physical.Count == 0) ModelState.AddModelError("", "Category not found.");
            return View(physical);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePhysicalService();
            var model = svc.GetPhysicalById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePhysicalService();
            var detail = service.GetPhysicalById(id);
            var model =
                new PhysicalEdit
                {
                    PhysicalId = detail.PhysicalId,
                    CategoryType = detail.CategoryType,
                    Title = detail.Title,
                    ResourceType = detail.ResourceType,
                    Description = detail.Description,
                    Url = detail.Url
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PhysicalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PhysicalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePhysicalService();

            if (service.UpdatePhysical(model))
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
            var svc = CreatePhysicalService();
            var model = svc.GetPhysicalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePhysicalService();

            service.DeletePhysical(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }

        private PhysicalService CreatePhysicalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicalService(userId);
            return service;
        }
    }
}
