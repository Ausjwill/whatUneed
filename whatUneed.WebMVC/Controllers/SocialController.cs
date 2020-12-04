using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using whatUneed.Data;
using whatUneed.Models.Favorites;
using whatUneed.Models.Social;
using whatUneed.Services;

namespace whatUneed.WebMVC.Controllers
{
    [Authorize]
    public class SocialController : Controller
    {
        // GET: Social
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SocialService(userId);
            var model = service.GetSocials();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string categoryType, string resourceType, string title)
        {
            var service = CreateSocialService();
            Enum.TryParse($"{categoryType}", out SocialCategory category);
            var cat = service.GetSocialByCategory(category);

            if (category == 0)
            {
                Enum.TryParse($"{resourceType}", out Resource resource);
                var res = service.GetSocialByResource(resource);

                if (resource == 0)
                {
                    var til = service.GetSocialByTitle(title);

                    if (title == null)
                    {
                        var per = service.GetSocialByInPerson();
                        return View(per);
                    }
                    return View(til);
                }
                return View(res);
            }
            return View(cat);
        }

        //GET: Social/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SocialCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSocialService();

            if (service.CreateSocial(model))
            {
                TempData["SaveResult"] = "Created successfully";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Entry could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSocialService();
            var model = svc.GetSocialById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSocialService();
            var detail = service.GetSocialById(id);
            var model =
                new SocialEdit
                {
                    SocialId = detail.SocialId,
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
        public ActionResult Edit(int id, SocialEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SocialId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSocialService();

            if (service.UpdateSocial(model))
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
            var svc = CreateSocialService();
            var model = svc.GetSocialById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSocialService();

            service.DeleteSocial(id);

            TempData["SaveResult"] = "Successfully deleted";

            return RedirectToAction("Index");
        }

        [ActionName("Add")]
        public ActionResult Add(int id)
        {
            var svc = CreateSocialService();
            var model = svc.GetSocialById(id);

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
                SocialId = id
            };

            if (service.CreateFavorites(favorite))
            {
                TempData["SaveResult"] = "Added to favorites";
                return RedirectToAction("Index");
            }

            TempData["SaveResult"] = "Already added to favorites";
            return RedirectToAction("Index");
        }

        private SocialService CreateSocialService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SocialService(userId);
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
