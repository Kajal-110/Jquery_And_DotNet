using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    public class HomeController : Controller
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index()
        {
            ViewBag.ItemList = new SelectList(db.Item.ToList(),"ItemId","ItemName");
            ViewBag.CustomerList = new SelectList(db.Customer.ToList(), "CustomerId", "CustomerName");
            ViewBag.PaymentList = new SelectList(db.Payment.ToList(), "PaymentId", "PaymentType");
           
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
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddItem(Item item)
        {
            KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
            db.Item.Add(item);
            db.SaveChanges();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddCustomer(Customer customer )
        {
            KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
            db.Customer.Add(customer);
            db.SaveChanges();
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddPayment(Payment payment)
        {
            KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
            db.Payment.Add(payment);
            db.SaveChanges();
            return View();
        }

        public JsonResult getItemUnitPrice(int? itemId)
        {
            //db.Configuration.ProxyCreationEnabled = false;
            Item item = db.Item.Find(itemId);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Transaction(Order ObjOrder)
        {
            AddOrder(ObjOrder);
            return Json(data: "Order has been Succefully Created ", JsonRequestBehavior.AllowGet);
        }

          

        public bool AddOrder(Order order)
        {
            
            db.Order.Add(order);
            db.SaveChanges();
            int OrderId = order.OrderId;
            foreach( var item in order.OrderDetail)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = OrderId;
                orderDetail.Discount = item.Discount;
                orderDetail.ItemId = item.ItemId;
                orderDetail.Total = item.Total;
                orderDetail.UnitPrice = item.UnitPrice;
                orderDetail.Quantity = item.Quantity;
                db.OrderDetail.Add(orderDetail);
                db.SaveChanges();

                Transactions transactions = new Transactions();
                transactions.ItemId = item.ItemId;
                transactions.Quantity = (-1) * item.Quantity;
                transactions.TransactionDate = DateTime.Now;
                transactions.TypeId = 2;
                db.Transactions.Add(transactions);
                db.SaveChanges();
            }

            return true;
        }
    }
}