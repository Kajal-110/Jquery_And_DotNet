using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krunal_Final_Test_Model.Model
{
   public class City_Model
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        [Display(Name = "County Name")]
        public Nullable<int> CountryId { get; set; }

        [Required]
        [Display(Name = "State Name")]
        public Nullable<int> StateId { get; set; }
    }
}
