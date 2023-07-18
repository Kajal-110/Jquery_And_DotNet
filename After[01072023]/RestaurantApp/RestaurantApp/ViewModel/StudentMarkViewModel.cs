using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.ViewModel
{
    public class StudentMarkViewModel
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string TotalMarks { get; set; }
        public string MarkObtained { get; set; }
        public string Percentage { get; set; }

    }
}