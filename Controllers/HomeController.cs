using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping_Site.Models;

namespace Shopping_Site.Controllers
{
    public class HomeController : Controller
    {
        ShoppingSiteDatabaseEntities2 db = new ShoppingSiteDatabaseEntities2();
        // GET: Home

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetail u)
        {
            UserDetail existinguser = db.UserDetails.Where(temp => temp.UserName == u.UserName && temp.Password==u.Password).FirstOrDefault();
            if (existinguser==null)
            {
                ViewBag.message="Not an existing user";
                return View();
            }
            Session["userId"] = existinguser.UserID;
            Session["name"] = existinguser.UserName;
            return RedirectToAction("Index", "Products");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Name,UserDetail u)
        {
            ViewBag.Name = Name;
            UserDetail existingusername = db.UserDetails.Where(temp => temp.UserName == u.UserName).FirstOrDefault();
            if(existingusername != null)
            {
                ViewBag.msg1 = "Username is not valid";
                return View();
            }
            db.UserDetails.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login","Home");
        }
    }
}