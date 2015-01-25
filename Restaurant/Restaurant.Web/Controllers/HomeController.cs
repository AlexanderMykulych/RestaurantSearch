using Restaurant.Domain.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using Restaurant.Domain.Entity;

namespace Restaurant.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantDb _db = new _RestaurantDb();
        public ActionResult Index(int? page, string searchTerm = null)
        {
            ViewBag.searchTerm = searchTerm;
            var model = _db.Restaurants
                                .Where(x => searchTerm == null || x.Name.StartsWith(searchTerm))
                               // .Where(x => x.Name.StartsWith("2"))
                                .OrderBy(x => x.Name)
                                .ToPagedList(page ?? 1, 10);

            if (Request.IsAjaxRequest())
            {

                return PartialView("_RestaurantsItem", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize(Roles="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                var model = _db.Restaurants
                            .Where(x => x.Id == id)
                            .FirstOrDefault();
                if(model != null)
                    return View(model);
            }
            
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public ActionResult Edit(RestaurantInfo model)
        {
            if(ModelState.IsValid)
            {
                var item = _db.Restaurants
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();

                item.Name = model.Name;
                item.Address = model.Address;
                item.Description = model.Description;

                _db.Save();

                TempData["Message"] = String.Format("Message: {0} is Edit!", model.Name);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id != null)
            {
                var model = _db.Restaurants
                        .Where(x => x.Id == id)
                        .FirstOrDefault();

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if(id != null)
            {
                var item = _db.Restaurants
                                        .Where(x => x.Id == id)
                                        .FirstOrDefault();
                if(item != null)
                    return View(item);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Delete(RestaurantInfo model)
        {
            if (model != null)
            {
                _db.Delete(model.Id);
                _db.Save();
                TempData["Message"] = String.Format("Message: {0} is delete!", model.Name);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RestaurantInfo model)
        {
            if(model != null)
            {
                _db.AddRestaurants(model);
                _db.Save();
                TempData["Message"] = String.Format("Message: {0} is Created!", model.Name);
            }
            return RedirectToAction("Index","Home");
        }

        public ActionResult AddReview(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var info = new RestaurantInfo() { Id = (int)id };

            var model = new Reviewe() { RestaurantInfo = info};
            return View(model);
        }
        [HttpPost]
        public ActionResult AddReview(Reviewe model)
        {
            var newReview = new Reviewe()
            {
                RestaurantInfo = _db.Restaurants
                                         .Where(x => x.Id == model.RestaurantInfo.Id)
                                         .First(),
                ReviewerMessage = model.ReviewerMessage,
                ReviewerName = model.ReviewerName
            };

            _db.AddReview(newReview);
            _db.Save();
            TempData["Message"] = String.Format("Message: {0} is add new review for {1} restaurant",
                                                    newReview.ReviewerName,
                                                    newReview.RestaurantInfo.Name);
            return RedirectToAction("Index");
        }
    }
}
