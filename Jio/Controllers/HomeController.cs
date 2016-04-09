using Jio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jio.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Edit()
        {
            string username = User.Identity.Name;

            ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));

            // Fetch the userprofile
            //ApplicationUser user = new ApplicationUser();
            //user.Email.FirstOrDefault(u => u.Equals(username));


            // Construct the viewmodel
            UserProfileEdit model = new UserProfileEdit();
            model.Fname = user.Fname;
            model.Lname = user.Lname;
            model.Address = user.Address;
            model.City = user.City;
            model.State = user.State;
            model.PostalCode = user.PostalCode;
            model.Country = user.Country;
            model.Phone = user.Phone;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileEdit userprofile)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.Name;
                // Get the userprofile
                //ApplicationUser user = new ApplicationUser();
                //user.Email.FirstOrDefault(u => u.Equals(username));
                ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                // Update fields
                user.Fname = userprofile.Fname;
                user.Lname = userprofile.Lname;
                user.Address = userprofile.Address;
                user.City = userprofile.City;
                user.State = userprofile.State;
                user.PostalCode = userprofile.PostalCode;
                user.Country = userprofile.Country;
                user.Phone = userprofile.Phone;              

                db.Entry(user).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index", "Home"); // or whatever
            }

            return View(userprofile);
        }

    }
}