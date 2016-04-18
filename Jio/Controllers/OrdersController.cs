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
    public class OrdersController : Controller
    {
        private JioEntities db = new JioEntities();

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Orders
        public ActionResult Index(string searchString)
        {
            var rest = from m in db.Orders
                       select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                rest = rest.Where(s => s.OrderId.ToString().Contains(searchString));
            }
            return View(rest);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [Authorize(Users = "ancrock@gmail.com")]

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Users = "ancrock@gmail.com")]

        public ActionResult OrderDetails (int? id)
        {
            var OrderDetails = db.OrderDetails.Include(m => m.Order).Where(g => g.OrderId == id);
            // menu_Item.ToList();
            // List<Menu_Item> menuitem = new List<Menu_Item>();
            // menuitem.Add(menu_Item);

            return View(OrderDetails);
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
