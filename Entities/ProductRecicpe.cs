using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class ProductRecicpe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string RecipeID { get; set; }
        public Recipe Recipe { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
    }
}
