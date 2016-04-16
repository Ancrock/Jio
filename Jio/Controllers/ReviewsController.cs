using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Jio.Models;

namespace Jio.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private JioEntities db = new JioEntities();

        // GET: Reviews
        public ActionResult Index()
        {
            var reviews = db.Reviews.Include(r => r.restaurant);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            return View(reviews);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name");
            return View();
        }
        [Authorize]
        public ActionResult CreateReview()
        {
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name");
            //return View();
            string username = User.Identity.Name;

            ApplicationUser user = db1.Users.FirstOrDefault(u => u.UserName.Equals(username));
            Reviews model = new Reviews();
            ShoppingCart shop = new ShoppingCart();
            model.UserName = user.Fname;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReview([Bind(Include = "ReviewsID,RestaurantID,UserName,Review,Recommendation")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Show_All", "Restaurants", new { area = "" });
            }

            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", reviews.RestaurantID);
            return View(reviews);
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewsID,RestaurantID,UserName,Review,Recommendation")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(reviews);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", reviews.RestaurantID);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", reviews.RestaurantID);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewsID,RestaurantID,UserName,Review,Recommendation")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reviews).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", reviews.RestaurantID);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reviews reviews = db.Reviews.Find(id);
            if (reviews == null)
            {
                return HttpNotFound();
            }
            return View(reviews);
        }

        public ActionResult Restaurant_Reviews(int? id)
        {
            var Reviews = db.Reviews.Include(m => m.restaurant).Where(g => g.RestaurantID == id);
            // menu_Item.ToList();
            // List<Menu_Item> menuitem = new List<Menu_Item>();
            // menuitem.Add(menu_Item);

            return View(Reviews);

        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reviews reviews = db.Reviews.Find(id);
            db.Reviews.Remove(reviews);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
