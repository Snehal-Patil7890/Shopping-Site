using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping_Site.Models;

namespace Shopping_Site.Controllers
{
    public class ProductsController : Controller
    {
        ShoppingSiteDatabaseEntities2 db = new ShoppingSiteDatabaseEntities2();

        // GET: Products
        public ActionResult Index()
        {
            List<ShoppingProduct> Products = db.ShoppingProducts.ToList();
            return View(Products);
        }

        [HttpGet]
        public ActionResult Add(long id)
        {
            ShoppingProduct existingProduct = db.ShoppingProducts.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Add(ShoppingProduct p)
        {
            ShoppingProduct existingProduct = db.ShoppingProducts.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            Cart newcart = new Cart();
            newcart.UserID = Convert.ToInt64(Session["userId"]);
            newcart.ProductName = existingProduct.ProductName;
            newcart.ProductPrice = existingProduct.ProductPrice;
            db.Carts.Add(newcart);
            db.SaveChanges();
            return RedirectToAction("Mycart", "Products");
        }

        public ActionResult Remove(long id)
        {
            Cart cartProduct = db.Carts.Where(temp => temp.CartID == id).FirstOrDefault();
            db.Carts.Remove(cartProduct);
            db.SaveChanges();
            return RedirectToAction("Mycart","Products");
        }
        public ActionResult Mycart()
        {
            long userID = Convert.ToInt64(Session["userId"]);
            List<Cart> mycarts = db.Carts.Where(temp => temp.UserID == userID ).ToList();
            return View(mycarts);
        }
        public ActionResult LogOut()
        {
            Session["name"] = null;
            Session["userId"] = null;
            return RedirectToAction("Login","Home");
        }
    }
}