using Krunal_Final_Test_Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Krunal_Final_Test_Model.Model
{
   public class User_Registration_Model
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "CountryName")]
        public Nullable<int> CountryId { get; set; }

        [Required]
        [Display(Name = "StateName")]
        public Nullable<int> StateId { get; set; }

        [Required]
        [Display(Name = "CityName")]
        public Nullable<int> CityId { get; set; }

        [Required]
        [Display(Name ="Profile Photo")]
        public string PhotoPath { get; set; }

        [Required]
        [Display(Name = "Upload Documents")]
        public string Docpath { get; set; }

        [Required]
        public Nullable<int> Gender { get; set; }

        [Required]
        public Nullable<int> Hobbies { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        public HttpPostedFileBase FileData { get; set; }

    }
}
