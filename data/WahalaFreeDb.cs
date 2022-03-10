using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WahalafreeAPI.Entities;

namespace WahalafreeAPI.data
{
    public class WahalaFreeDb : DbContext
    {
        public WahalaFreeDb(DbContextOptions<WahalaFreeDb> options) : base(options){ }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<RecipeDetail> recipeDetails { get; set; }
        public DbSet<Occasion> occasions { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }
        public DbSet<ProductOccasion> productOccasions { get; set; }
        public DbSet<RecipeOccasion> recipeOccasions { get; set; }
        public DbSet<ProductRecicpe> productRecicpes { get; set; }
        public DbSet<Delivery> deliveries { get; set; }
        public DbSet<DeliveryCost> deliveryCosts { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<RegisterCustomer> registerCustomers { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Customer> customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //---------------------------------USER-------------------------
            modelBuilder.Entity<Customer>().HasIndex(u => u.CustomerEmail).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<RegisterCustomer>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Address>().HasIndex(u => new { u.AddressLine1, u.Postcode }).IsUnique();
            //---------------------PRODUCT OCCASION----------------------------
            modelBuilder.Entity<ProductOccasion>()
                .HasKey(p => new { p.ProductID, p.OccasionID });
            modelBuilder.Entity<ProductOccasion>()
                .HasOne(pt => pt.Product)
                .WithMany(oc => oc.ProductOccasions)
                .HasForeignKey(pt => pt.ProductID);

            modelBuilder.Entity<ProductOccasion>()
                .HasOne(po => po.Occasion)
                .WithMany(o => o.ProductOccasions)
                .HasForeignKey(po => po.OccasionID);

//------------------------------------RECIPE OCCATION------------------------------------------------------------
            modelBuilder.Entity<RecipeOccasion>()
              .HasKey(p => new { p.RecipeID, p.OccasionID });
            modelBuilder.Entity<RecipeOccasion>()
                .HasOne(ro => ro.Recipe)
                .WithMany(o => o.RecipeOccasions)
                .HasForeignKey(ro => ro.RecipeID);

            modelBuilder.Entity<RecipeOccasion>()
                .HasOne(ro => ro.Occasion)
                .WithMany(o => o.RecipeOccasions)
                .HasForeignKey(po => po.OccasionID);
            //------------------------------------------------PRODUCT RECIPE-----------------------
            modelBuilder.Entity<ProductRecicpe>()
               .HasKey(k => new { k.ProductID, k.RecipeID });
            modelBuilder.Entity<ProductRecicpe>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.ProductRecicpes)
                .HasForeignKey(pr => pr.ProductID);
            modelBuilder.Entity<ProductRecicpe>()
                .HasOne(rp => rp.Recipe)
                .WithMany(r => r.ProductRecicpes)
                .HasForeignKey(rp => rp.    RecipeID);
            //---------------------PRODUCT CATEGORY-----------------------------------
            modelBuilder.Entity<ProductCategory>().HasKey(k => new { k.ProductID, k.CategoryID });
            modelBuilder.Entity<ProductCategory>()
                .HasOne(cc => cc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(cc => cc.CategoryID);
            modelBuilder.Entity<ProductCategory>()
               .HasOne(pp => pp.Product)
               .WithMany(P => P.ProductCategories)
               .HasForeignKey(PP => PP.ProductID);

        }

    }
   
}
