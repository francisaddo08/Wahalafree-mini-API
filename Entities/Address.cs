using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class Address
    {
      public  enum  AddressType {BOTH, DELIVERY, PAYMENT}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = " First Name not more than 8 characters")]
        public string Postcode { get; set; }
        public AddressType Type { get; set; }
    }
}
