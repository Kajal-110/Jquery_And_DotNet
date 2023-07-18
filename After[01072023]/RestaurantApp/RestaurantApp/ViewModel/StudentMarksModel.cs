using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.ViewModel
{
    public class StudentMarksModel
    {
        public int StudentId { get; set; }
        public string SubjectName { get; set; }
        public string TotalMarks { get; set; }
        public string MarkObtained { get; set; }
        public string Percentage { get; set; }
    }
}