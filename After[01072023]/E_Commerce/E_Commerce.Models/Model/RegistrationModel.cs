using E_Commerce.Models.DbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.Models.Model
{
    public class RegistrationModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please select your country.")]
        public Nullable<int> CountryId { get; set; }
        [Required(ErrorMessage = "Please select your state.")]
        public Nullable<int> StateId { get; set; }
        [Required(ErrorMessage = "Please select your city.")]
        public Nullable<int> CityId { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }

        public string CityName { get; set; }

        [Required(ErrorMessage = "Please select your Profile_Picture.")]
        public string Profile_Picture { get; set; }

        [Required(ErrorMessage = "Please select your Profile_Picture.")]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        public string Gender { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}
