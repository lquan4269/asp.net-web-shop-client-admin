using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart
        //public ActionResult Catelogy()
        //{
        //    var cart = Session["Catelogy"];
        //    var listItem = new List<Catelogy>();
        //    if (cart != null)
        //    {
        //        listItem = (List<Catelogy>)cart;
        //    }
        //    return View(listItem);
        //}
        [HttpPost]
        public ActionResult AddToCart(ItemDetail model)
        {
             var sessionID = HttpContext.Session.SessionID;
            ViewBag.SessionID = sessionID;
            Cart carts = (Cart)HttpContext.Session["cart"];
            if (carts == null)
            {
                carts = new Cart();
                carts.AddToCart(model);
                HttpContext.Session.Add("cart", carts);
            }
            else
            {
                carts.AddToCart(model);
                HttpContext.Session.Add("cart", carts);
            }
            List<ItemDetail> items = carts.getAllItems();
            ViewBag.Total = carts.getTotal();
            return View("Catelogy", items);

        }
        //public ActionResult Update_Quantity_Cart(int id, int soluong)
        //{
        //    List<ItemDetail> cart = Session["Cart"] as List<ItemDetail>;
        //    Catelogy UpdateCart = cart.FirstOrDefault(x => x.Cartelogy_ID == id); //FirstOrDefault linq giá trị mặc định khác null
        //    if (UpdateCart != null)
        //    {
        //        UpdateCart.SoLuong = soluong;
        //    }
        //    return RedirectToAction("Index", "Cart");
        //}


 
        public ActionResult RemoveCart(ItemDetail model, int id)
        {
            List<ItemDetail> cart = Session["cart"] as List<ItemDetail>;
            ItemDetail deletecart = cart.FirstOrDefault(x => x.productDetai.Product_ID == id);
            if (deletecart != null)
            {
                cart.Remove(deletecart);
            }
            return View("Catelogy");
        }

        public ActionResult ThanhToan()
        {
            var cart = Session["cart"];
            var listItem = new List<ItemDetail>();
            if (cart != null)
            {
                listItem = (List<ItemDetail>)cart;
            }
            return View(listItem);
        }

        public ActionResult CheckOut(FormCollection form)
        {
            int? total = 0;
            List<ItemDetail> ListCart = Session["cart"] as List<ItemDetail>;
            foreach (ItemDetail cart in ListCart)
            {
                total += cart.Quantity * cart.productDetai.Product_price;
            }
            Order bill = new Order()
            {
                Payment = form["Name"],
                Adress = form["Adress"],
                Date = DateTime.Now,
                Status = 0,
                Total = total
            };
            // 2 câu truy vấn kề nhau chạy 2 lần (đóng gói trong 1 trainstion)
            db.Orders.Add(bill);
            db.SaveChanges();
            foreach (ItemDetail cart in ListCart)
            {
                OrderDetail billDetail = new OrderDetail()
                {
                    CartID = bill.CartID,
                    Product_ID = cart.productDetai.Product_ID,
                    Amount = cart.Quantity,
                    Price = cart.productDetai.Product_price
                };
                db.OrderDetails.Add(billDetail);
                db.SaveChanges();
            }
            Session.Remove("Catelogy");
            return View(bill);
        }
    }
}
