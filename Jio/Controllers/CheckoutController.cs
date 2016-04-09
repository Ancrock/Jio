using Jio.Models;
using Jio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jio.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        JioEntities storeDB = new JioEntities();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment(decimal Decimal)
        {


            string username = User.Identity.Name;
           
            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
            Order model = new Order();
            ShoppingCart shop = new ShoppingCart();
            model.FirstName = user.Fname;
            model.LastName = user.Lname;
            model.Address = user.Address;
            //model.Phone = user.Card;
            model.Total = Decimal;
          

            return View(model);
        }
        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;
                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete",
                    new { id = order.OrderId });
                }
            }
catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
            o => o.OrderId == id &&
            o.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}