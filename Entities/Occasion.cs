using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class Occasion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public bool promoted { get; set; }
        public virtual ICollection<ProductOccasion> ProductOccasions { get; set; }
        public virtual ICollection<RecipeOccasion> RecipeOccasions { get; set; }
    }
}
