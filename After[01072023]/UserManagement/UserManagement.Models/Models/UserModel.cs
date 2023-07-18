using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UserManagement.Models.Models
{
   public  class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
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
        public Nullable<int> CountryId { get; set; }
        [Required]
        public Nullable<int> StateId { get; set; }
        [Required]
        public Nullable<int> CityId { get; set; }
        [Required]
        public byte[] Attachment { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Hobbies { get; set; }
        [Required]
        public string Profile { get; set; }

        [Display(Name ="Upload Image")]
        public HttpPostedFileBase IMAGEPath { get; set; }

        public string CountryName { get; set; }
        public string Statename { get; set; }
        public string CityName { get; set; }

        [Required]
        [Display(Name ="Browse File")]
        public HttpPostedFileBase[] files { get; set; }


      
    }
}
