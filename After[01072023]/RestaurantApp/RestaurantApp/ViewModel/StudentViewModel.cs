using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.ViewModel
{
    public class StudentViewModel
    {
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public int ExamId { get; set; }
        public string RollNumber { get; set; }

        public List<StudentMarkViewModel> ListOfStudentMark { get; set; }

       
    }
}