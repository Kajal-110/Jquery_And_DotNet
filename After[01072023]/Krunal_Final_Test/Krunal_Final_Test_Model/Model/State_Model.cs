using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krunal_Final_Test_Model.Model
{
    public class State_Model
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string StateName { get; set; }

        [Required]
        [Display(Name = "Country Name")]
        public int CountryId { get; set; }
    }
}
