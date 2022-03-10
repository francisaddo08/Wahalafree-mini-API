using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.ViewModels
{
    public class CustomerViewModel
    {
       
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname  is Required")]
        public string SurName { get; set; }
    }
}
