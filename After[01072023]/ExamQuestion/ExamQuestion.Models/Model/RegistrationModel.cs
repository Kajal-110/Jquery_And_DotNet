using ExamQuestion.Models.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExamQuestion.Models.Model
{
    public class RegistrationModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<System.DateTime> Date_of_birth { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Profile_photo { get; set; }
        public HttpPostedFileBase IMAGEPath { get; set; }
      
        public string Attachment { get; set; }

        public HttpPostedFileBase AttachmentFilePath { get; set; }

        public string Gender { get; set; }
        public string Hobbies { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }

        public Nullable<bool> IsIntrestedInDanching { get; set; }
        public Nullable<bool> IsIntrestedInReading { get; set; }
        public Nullable<bool> IsIntrestedInCooking { get; set; }




    }
}
