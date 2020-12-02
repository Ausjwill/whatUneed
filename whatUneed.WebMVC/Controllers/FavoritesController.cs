using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using whatUneed.Services;

namespace whatUneed.WebMVC.Controllers
{
    public class FavoritesController : Controller
    {
        public ActionResult Index()
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavorites();

            return View(model);
        }

        public ActionResult EmotionalDetails(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesByEmotionalId(id);

            return View(model);
        }

        public ActionResult PhysicalDetails(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesByPhysicalId(id);

            return View(model);
        }

        public ActionResult SocialDetails(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesBySocialId(id);

            return View(model);
        }

        public ActionResult FinancialDetails(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesByFinancialId(id);

            return View(model);
        }

        [ActionName("EmotionalRemove")]
        public ActionResult EmotionalRemove(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesByEmotionalId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("EmotionalRemove")]
        [ValidateAntiForgeryToken]
        public ActionResult EmotionalRemovePost(int id)
        {
            var service = CreateFavoriteService();

            service.RemoveFavoritesByEmotionalId(id);

            TempData["SaveResult"] = "Successfully removed";

            return RedirectToAction("Index");
        }

        [ActionName("PhysicalRemove")]
        public ActionResult PhysicalRemove(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesByPhysicalId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("PhysicalRemove")]
        [ValidateAntiForgeryToken]
        public ActionResult PhysicalRemovePost(int id)
        {
            var service = CreateFavoriteService();

            service.RemoveFavoritesByPhysicalId(id);

            TempData["SaveResult"] = "Successfully removed";

            return RedirectToAction("Index");
        }

        [ActionName("SocialRemove")]
        public ActionResult SocialRemove(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesBySocialId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("SocialRemove")]
        [ValidateAntiForgeryToken]
        public ActionResult SocialRemovePost(int id)
        {
            var service = CreateFavoriteService();

            service.RemoveFavoritesBySocialId(id);

            TempData["SaveResult"] = "Successfully removed";

            return RedirectToAction("Index");
        }

        [ActionName("FinancialRemove")]
        public ActionResult FinancialRemove(int id)
        {
            var svc = CreateFavoriteService();
            var model = svc.GetFavoritesByFinancialId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("FinancialRemove")]
        [ValidateAntiForgeryToken]
        public ActionResult FinancialRemovePost(int id)
        {
            var service = CreateFavoriteService();

            service.RemoveFavoritesByFinancialId(id);

            TempData["SaveResult"] = "Successfully removed";

            return RedirectToAction("Index");
        }

        private FavoritesService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoritesService(userId);
            return service;
        }
    }
}
