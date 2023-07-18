using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    public class PaginationController : Controller
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
        // GET: Pagination

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GetStudentList(int PageNumber = 1)
        {
            var StudentList = db.StudentMaster.ToList();
            StudentList = ApplyPagination(StudentList, PageNumber);
            return View(StudentList);
        }

        public List<StudentMaster> ApplyPagination(List<StudentMaster> StudentList, int PageNumber)
        {
            ViewBag.TotalPages = Math.Ceiling(StudentList.Count() / 5.0);
            ViewBag.PageNumber = PageNumber;
            StudentList = StudentList.Skip((PageNumber - 1) * 5).Take(5).ToList();
            return StudentList;
        }

        public ActionResult Index()
        {
            var StudentList = db.StudentMaster.ToList();           
            return View(StudentList);
        }
    }
}