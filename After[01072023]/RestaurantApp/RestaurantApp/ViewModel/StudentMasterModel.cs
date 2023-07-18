using RestaurantApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class StudentMasterModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ExamId { get; set; }
        public string ClassName { get; set; }
        public string RollNumber { get; set; }


        public virtual Exam Exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentDetails> StudentDetails { get; set; }

        public int SubjectId { get; set; }
        public string TotalMarks { get; set; }
        public string MarkObtained { get; set; }

        public decimal Percentage { get; set; }

        public List<StudentModel> ListOfStudentModel { get; set; }
    }
}