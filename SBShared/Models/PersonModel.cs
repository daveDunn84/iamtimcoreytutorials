using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBShared.Models
{
    public class PersonModel
    {
        [Required] // this allows us to specifiy this as required on the form
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
