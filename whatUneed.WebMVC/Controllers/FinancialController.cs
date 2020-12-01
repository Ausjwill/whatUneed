using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using whatUneed.Data;
using whatUneed.Models.Favorites;
using whatUneed.Models.Financial;
using whatUneed.Services;

namespace whatUneed.WebMVC.Controllers
{
    [Authorize]
    public class FinancialController : Controller
    {
        // GET: Financial
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FinancialService(userId);
            var model = service.GetFinancials();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string categoryType, string resourceType, string title)
        {
            var service = CreateFinancialService();
            Enum.TryParse($"{categoryType}", out FinancialCategory category);
            var cat = service.GetFinancialByCategory(category);

            if (category == 0)
            {
                Enum.TryParse($"{resourceType}", out Resource resource);
                var res = service.GetFinancialByResource(resource);

                if (resource == 0)
                {
                    var til = service.GetFinancialByTitle(title);

                    if (title == null)
                    {
                        var per = service.GetFinancialByInPerson();
                        return View(per);
                    }
                    return View(til);
                }
                return View(res);
            }
            return View(cat);
        }

        //GET: Financial/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FinancialCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFinancialService();

            if (service.CreateFinancial(model))
            {
                TempData["SaveResult"] = "Your entry was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFinancialService();
            var model = svc.GetFinancialById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFinancialService();
            var detail = service.GetFinancialById(id);
            var model =
                new FinancialEdit
                {
                    FinancialId = detail.FinancialId,
                    CategoryType = detail.CategoryType,
                    Title = detail.Title,
                    ResourceType = detail.ResourceType,
                    Description = detail.Description,
                    City = detail.City,
                    State = detail.State,
                    InPerson = detail.InPerson,
                    AddToFavorites = detail.AddToFavorites,
                    Url = detail.Url,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FinancialEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FinancialId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFinancialService();

            if (service.UpdateFinancial(model))
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
            var svc = CreateFinancialService();
            var model = svc.GetFinancialById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFinancialService();

            service.DeleteFinancial(id);

            TempData["SaveResult"] = "Your entry was deleted";

            return RedirectToAction("Index");
        }

        public ActionResult AddToFavorites(int id)
        {
            var service = CreateFavoriteService();
            var favorite = new FavoritesCreate();
            favorite.FinancialId = id;
            service.CreateFavorites(favorite);

            return RedirectToAction("Index");
        }

        private FinancialService CreateFinancialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FinancialService(userId);
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
