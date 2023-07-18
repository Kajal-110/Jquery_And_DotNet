using RestaurantApp.Models;
using RestaurantApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantApp.Controllers
{
    public class StudentExamReportController : Controller
    {
        KajalPatel_01_07_2023Entities db = new KajalPatel_01_07_2023Entities();
        

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index()
        {
            StudentMasterModel studentMasterModel = new StudentMasterModel();
            ViewBag.ItemList = new SelectList(db.Exam.ToList(), "ExamId", "ExamName");
            ViewBag.SubjectList = new SelectList(db.Subject.ToList(), "SubjectId", "SubjectName");

            List<StudentModel> listOfStudentModel =
            (
                from objStu in db.StudentMaster
                join
                objExam in db.Exam on objStu.ExamId equals objExam.ExamId
                select new StudentModel()
                {
                    ClassName= objStu.ClassName,
                    RollNumber= objStu.RollNumber,
                    StudentId= objStu.StudentId,
                    StudentName= objStu.Name,
                    ExamName= objStu.Name
                }
            ).ToList();

            studentMasterModel.ListOfStudentModel = listOfStudentModel;
            return View(studentMasterModel);
        }

        public ActionResult Create(StudentViewModel studentViewModel)
        {
            StudentMaster studentMaster = new StudentMaster()
            {
                Name = studentViewModel.StudentName,
                ClassName = studentViewModel.ClassName,
                ExamId = studentViewModel.ExamId,
                RollNumber = studentViewModel.RollNumber
            };
            db.StudentMaster.Add(studentMaster);
            db.SaveChanges();

            foreach(var item in studentViewModel.ListOfStudentMark)
            {
                StudentDetails studentDetails = new StudentDetails()
                {
                    MarkObtained = item.MarkObtained,
                    Percentage=item.Percentage,
                    SubjectId = item.SubjectId,
                    StudentId= studentMaster.StudentId,
                    TotalMarks=item.TotalMarks
                };
                db.StudentDetails.Add(studentDetails);
                db.SaveChanges();
            }
            return Json(data: new { message ="Data Added Successfully..",status=true},JsonRequestBehavior.AllowGet);
        }
       public PartialViewResult GetStudentMarks(int StudentId)
        {
            List<StudentMarksModel> listOfStudentMarksModel =
                (
                    from obj in db.StudentDetails
                    join
                    objStd in db.Subject on obj.SubjectId equals objStd.SubjectId
                    where obj.StudentId == StudentId
                    select new StudentMarksModel()
                    {
                        StudentId = StudentId,
                        SubjectName=objStd.SubjectName,
                        MarkObtained=obj.MarkObtained,
                        TotalMarks=obj.TotalMarks,
                        Percentage=obj.Percentage
                    }
                ).ToList();
            return PartialView("_StudentMarksPartial");
        }
    }
}