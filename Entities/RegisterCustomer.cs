using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class RegisterCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password  is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
