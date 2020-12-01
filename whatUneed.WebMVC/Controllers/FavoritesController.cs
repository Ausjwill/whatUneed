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
        // GET: Favorites
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoritesService(userId);
            var model = service.GetFavorites();

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

        private FavoritesService CreateFavoriteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoritesService(userId);
            return service;
        }
    }
}
