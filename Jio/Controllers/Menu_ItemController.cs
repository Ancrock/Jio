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
    public class Menu_ItemController : Controller
    {
        private JioEntities db = new JioEntities();

        // GET: Menu_Item
        [Authorize(Users ="ancrock@gmail.com") ]
        public ActionResult Index(string searchString)
        {
            var menu_Item = db.menu_item.Include(m => m.restaurant);
            //var rest = from m in db.restaurants
            //           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                menu_Item = menu_Item.Where(s => s.restaurant.Name.Contains(searchString));
            }
            return View(menu_Item.ToList());
        }

        [Authorize(Users = "ancrock@gmail.com")]


        // GET: Menu_Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.menu_item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            return View(menu_Item);
        }
        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Menu_Item/Create
        public ActionResult Create()
        {
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name");
            return View();
        }

        // POST: Menu_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "ancrock@gmail.com")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Menu_ItemID,RestaurantID,Item_Name,description,AlbumArtUrl,price")] Menu_Item menu_Item)
        {
            if (ModelState.IsValid)
            {
                db.menu_item.Add(menu_Item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", menu_Item.RestaurantID);
            return View(menu_Item);
        }
        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Menu_Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.menu_item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", menu_Item.RestaurantID);
            return View(menu_Item);
        }

        // POST: Menu_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "ancrock@gmail.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Menu_ItemID,RestaurantID,Item_Name,description,AlbumArtUrl,price")] Menu_Item menu_Item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menu_Item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestaurantID = new SelectList(db.restaurants, "RestaurantID", "Name", menu_Item.RestaurantID);
            return View(menu_Item);
        }
        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Menu_Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.menu_item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            return View(menu_Item);
        }
        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Menu_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu_Item menu_Item = db.menu_item.Find(id);
            db.menu_item.Remove(menu_Item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Restaurant_Menu(int? id)
        {
            var menu_Item = db.menu_item.Include(m => m.restaurant).Where(g => g.RestaurantID == id);
            // menu_Item.ToList();
            // List<Menu_Item> menuitem = new List<Menu_Item>();
            // menuitem.Add(menu_Item);

            return View(menu_Item);
        }

        public ActionResult MenuItemDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu_Item menu_Item = db.menu_item.Find(id);
            if (menu_Item == null)
            {
                return HttpNotFound();
            }
            return View(menu_Item);
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
