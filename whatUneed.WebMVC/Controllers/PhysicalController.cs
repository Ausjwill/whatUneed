using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using whatUneed.Data;
using whatUneed.Models.Favorites;
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

        [HttpPost]
        public ActionResult Index(string categoryType, string resourceType, string title)
        {
            var service = CreatePhysicalService();
            Enum.TryParse($"{categoryType}", out PhysicalCategory category);
            var cat = service.GetPhysicalByCategory(category);

            if (category == 0)
            {
                Enum.TryParse($"{resourceType}", out Resource resource);
                var res = service.GetPhysicalByResource(resource);

                if (resource == 0)
                {
                    var til = service.GetPhysicalByTitle(title);

                    if (title == null)
                    {
                        var per = service.GetPhysicalByInPerson();
                        return View(per);
                    }
                    return View(til);
                }
                return View(res);
            }
            return View(cat);
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
                TempData["SaveResult"] = "Created successfully";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");
            return View(model);
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
                    City = detail.City,
                    State = detail.State,
                    InPerson = detail.InPerson,
                    Url = detail.Url,
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
                TempData["SaveResult"] = "Successfully updated.";
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

            TempData["SaveResult"] = "Successfully deleted";

            return RedirectToAction("Index");
        }

        [ActionName("Add")]
        public ActionResult Add(int id)
        {
            var svc = CreatePhysicalService();
            var model = svc.GetPhysicalById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult AddToFavorites(int id)
        {
            var service = CreateFavoriteService();
            var favorite = new FavoritesCreate
            {
                PhysicalId = id
            };

            if (service.CreateFavorites(favorite))
            {
                TempData["SaveResult"] = "Added to favorites";

                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Already added to favorites";
            return RedirectToAction("Index");
        }

        private PhysicalService CreatePhysicalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PhysicalService(userId);
            return service;
        }

        private FavoritesService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoritesService(userId);
            return service;
        }
    }
}
