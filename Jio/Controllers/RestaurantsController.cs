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
    public class RestaurantsController : Controller
    {
        private JioEntities db = new JioEntities();
        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Restaurants
        public ActionResult Index(string searchString)
        {
            var rest = from m in db.restaurants
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                rest = rest.Where(s => s.Name.Contains(searchString));
            }

            return View(rest);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantID,Name,Description,Owner,Contact,address")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,Name,Description,Owner,Contact,address")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.restaurants.Find(id);
            db.restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Show_All()
        //{
        //    return View(db.restaurants.ToList());
        //}

        public ActionResult Show_All(string searchString, string description)
        {
            
            var rest = from m in db.restaurants
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                rest = rest.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(description))
            {
                rest = rest.Where(s => s.Description.Contains(description));
            }

            return View(rest);
            }
           // return View(db.restaurants.ToList());

   

        

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
