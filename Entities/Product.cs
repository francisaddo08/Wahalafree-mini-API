using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WahalafreeAPI.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public double price { get; set; }
        public int stockLevel { get; set; }
        public bool justLanded { get; set; }
        public string pdesc { get; set; }
        public virtual ICollection<ProductOccasion> ProductOccasions { get; set; }
        public virtual ICollection<ProductRecicpe> ProductRecicpes { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}