using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index()
        {

            List<Product> products = db.Products.ToList();
            return View(products);
        }

        public ActionResult Checkout()
        {

            return View();
        }

        public ActionResult Cart()
        {

            return View();
        }

        public ActionResult Shop()
        {

            List<Product> products = db.Products.ToList();
            return View(products);
        }


    }
}