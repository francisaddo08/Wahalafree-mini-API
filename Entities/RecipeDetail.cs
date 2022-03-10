using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WahalafreeAPI.Entities
{
    public class RecipeDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [ForeignKey("RecipeDetail")]
        [Display(Name ="recipe")]
        public string recipeid { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string line3 { get; set; }
        public string line4 { get; set; }
        public string line5 { get; set; }
        public string line6 { get; set; }
        public string line7 { get; set; }
        public string line8 { get; set; }
        public string line9 { get; set; }
        public string line10 { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
