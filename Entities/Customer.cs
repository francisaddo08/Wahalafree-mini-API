using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("RegisterCustomer")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname  is Required")]
        public string SurName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
