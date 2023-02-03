using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {

            Product sp = db.Products.FirstOrDefault(x => x.Product_ID == id);
            ItemDetail model = new ItemDetail()
            {
                productDetai = sp,
                Quantity =1
            };
            return View(model);
        }
    }
}