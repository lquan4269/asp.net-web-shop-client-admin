using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
namespace web.Controllers
{
    public class AdminController : Controller
    {
        //GET: Admin
        Model1 db = new Model1();
        public ActionResult Index()
        {
            List<Catelogy> cagelogy = db.Catelogies.ToList();
            return View(cagelogy);
        }

        public ActionResult UserList()
        {
            List<User> users = db.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            // tim chinh xac mot doi tuong co id tuong ung  //SingleOrDefault trả về phần tử duy nhất của chuỗi
            User user = db.Users.Where(u => u.ID == id).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                // update into table category
                User userdb = db.Users.Where(u => u.ID == user.ID).SingleOrDefault();
                //update category name
                userdb.Name = user.Name;
                userdb.Email = user.Email;
                userdb.Phone = user.Phone;
                userdb.Adress = user.Adress;
                userdb.Password = user.Password;

                db.SaveChanges();

                return RedirectToAction("UserList");
            }
            return View(user);

        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            //remove item in db
            User userdb = db.Users.Where(u => u.ID == id).SingleOrDefault();
            db.Users.Remove(userdb);
            db.SaveChanges();
            return RedirectToAction("UserList");
        }

        public ActionResult ProductList()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }


        [HttpGet]
        public ActionResult EditCatelogy(int id)
        {
            // tim chinh xac mot doi tuong co id tuong ung  //SingleOrDefault trả về phần tử duy nhất của chuỗi
            Catelogy catelogy = db.Catelogies.Where(c => c.Cartelogy_ID == id).SingleOrDefault(); 
            return View(catelogy);
        }
        [HttpPost]
        public ActionResult EditCatelogy(Catelogy catelogy)
        {
            if (ModelState.IsValid)
            {
                // update into table category
                Catelogy catelogydb = db.Catelogies.Where(c => c.Cartelogy_ID == catelogy.Cartelogy_ID).SingleOrDefault();
                //update category name
                catelogydb.CartelogyName = catelogy.CartelogyName;
                catelogydb.SoLuong = catelogy.SoLuong;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(catelogy);

        }

        [HttpGet]
        public ActionResult DeleteCatelogy(int id)
        {
            //remove item in db
            Catelogy catelogydb = db.Catelogies.Where(c => c.Cartelogy_ID == id).SingleOrDefault();
            db.Catelogies.Remove(catelogydb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateCatelogy()
        {
            Catelogy catelogy = new Catelogy();
            return View(catelogy);

        }

        [HttpPost]
        public ActionResult CreateCatelogy(Catelogy catelogy)
        {
            if (ModelState.IsValid)
            {

                // insert into table category
                db.Catelogies.Add(catelogy);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(catelogy);

        }




        [HttpGet]
        public ActionResult CreateProduct()
        {
            Product product = new Product();
            //B2. Tao view
            return View(product);

        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
                db.Products.Add(product);
                db.SaveChanges();
                //B2. Tao view
                return View(product);

        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            // tim chinh xac mot doi tuong co id tuong ung  //SingleOrDefault trả về phần tử duy nhất của chuỗi
            Product product = db.Products.Where(p => p.Product_ID == id).SingleOrDefault();
            return View(product);
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                // update into table category
                Product productdb = db.Products.Where(p => p.Product_ID == product.Product_ID).SingleOrDefault();
                //update category name
                productdb.Product_name = product.Product_name;
                productdb.Product_price = product.Product_price;
                productdb.Product_Type = product.Product_Type;
                productdb.Product_images = product.Product_images;
                productdb.CatelogyID = product.CatelogyID;

                db.SaveChanges();

                return RedirectToAction("ProductList");
            }
            return View(product);

        }
        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            //remove item in db
            Product productdb = db.Products.Where(p => p.Product_ID == id).SingleOrDefault();
            db.Products.Remove(productdb);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}