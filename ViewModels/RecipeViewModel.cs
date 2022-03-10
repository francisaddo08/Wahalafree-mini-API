using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.ViewModels
{
    public class RecipeViewModel
    {
        public string recipeId { get; set; }
        public string name { get; set; }
        public string origin { get; set; }
        public string subregion { get; set; }
        public string imageUrl { get; set; }
        public string duration { get; set; }
        public int ingredientCount { get; set; }
        public bool promoted { get; set; }
        public string recipeDes { get; set; }
        public string desDetail { get; set; }
    }
}
