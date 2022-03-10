using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class PromotionRecipe
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
        public virtual ICollection<Product> ingredients { get; set; }
    }
}
