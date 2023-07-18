using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    public class OrdersController : Controller
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();

        // GET: Orders
        public ActionResult Index()
        {
            var OrderAndCustomerList = db.Customer1.ToList();
            return View(OrderAndCustomerList);
        }

        public ActionResult Create( string Name,string Address, Orders[] orders,Orders order )
        {
            string result = "Error ! Order is not Completed";
            //if(Name != null || Address!= null || orders != null)
            //{
            //    var customerId = Guid.NewGuid();
            //    Customer1 model = new Customer1();
            //    //model.CustomerId = customer.CustomerId;
            //    model.Name = Name;
            //    model.Address = Address;
            //    model.OrderDate = DateTime.Now;
            //    db.Customer1.Add(model);
            //    foreach(var item in orders)
            //    {
            //        //var orderId = Guid.NewGuid();
            //        //int OrderId = order.OrderId;
            //        Orders orders1 = new Orders();
            //        //orders1.OrderId = orderId;
            //        orders1.ProductName = item.ProductName;
            //        orders1.Quantity = item.Quantity;
            //        orders1.Price = item.Price;
            //        orders1.Amount = item.Amount;
            //        orders1.CustomerId = model.CustomerId;
            //        db.Orders.Add(orders1);
            //    }
            //    db.SaveChanges();
            //    result = " Success !  Order in Completed";
            //}
            //return Json(result,JsonRequestBehavior.AllowGet);

            Customer1 customer = new Customer1()
            {
                Name = customer.Name,
                Address = customer.Address,
                OrderDate = DateTime.Now
            };
            db.Customer1.Add(customer);
            db.SaveChanges();
            foreach (var item in order.)
            {
                Orders orders2 = new Orders()
                {
                    ProductName = order.ProductName,
                    Quantity = order.Quantity,
                    Price = order.Price,
                    Amount = order.Amount,
                    CustomerId = order.CustomerId
                };
                db.Orders.Add(orders2);
                db.SaveChanges();
            }
            return Json(result, JsonRequestBehavior.AllowGet);


        }
    }
}

//public ActionResult Create(StudentViewModel studentViewModel)
//{
//    StudentMaster studentMaster = new StudentMaster()
//    {
//        Name = studentViewModel.StudentName,
//        ClassName = studentViewModel.ClassName,
//        ExamId = studentViewModel.ExamId,
//        RollNumber = studentViewModel.RollNumber
//    };
//    db.StudentMaster.Add(studentMaster);
//    db.SaveChanges();

//    foreach (var item in studentViewModel.ListOfStudentMark)
//    {
//        StudentDetails studentDetails = new StudentDetails()
//        {
//            MarkObtained = item.MarkObtained,
//            Percentage = item.Percentage,
//            SubjectId = item.SubjectId,
//            StudentId = studentMaster.StudentId,
//            TotalMarks = item.TotalMarks
//        };
//        db.StudentDetails.Add(studentDetails);
//        db.SaveChanges();
//    }
//    return Json(data: new { message = "Data Added Successfully..", status = true }, JsonRequestBehavior.AllowGet);
//}