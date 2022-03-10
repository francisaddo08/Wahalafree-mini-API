using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WahalafreeAPI.Entities;

namespace WahalafreeAPI.Entities
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string id { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public string subregion { get; set; }
        public string imageUrl { get; set; }
        public string duration { get; set; }
        public int ingredientcount { get; set; }
        public bool promoted { get; set; }
        public string recipeDes { get; set; }
        public string desDetail { get; set; }
        public virtual ICollection<ProductRecicpe> ProductRecicpes { get; set; }
        public virtual ICollection<RecipeOccasion> RecipeOccasions { get; set; }
    }
}
