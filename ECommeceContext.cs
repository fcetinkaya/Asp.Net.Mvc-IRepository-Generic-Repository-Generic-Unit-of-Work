using MVC5_ECommece.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5_ECommece.Data
{
    public class ECommeceContext : DbContext
    {
        public ECommeceContext() : base("ecommececontext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ECommeceContext>());
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }


        // Fluent Api...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product").HasKey<int>(p => p.Id)
                .Property(c => c.Name).IsRequired().HasMaxLength(60); // Boş geçilemez ve Max 60 karakter 

            modelBuilder.Entity<Category>().ToTable("Category").HasKey<int>(p => p.Id).Property(p => p.ShortDescription).HasMaxLength(250); // ShortDescription sütunu için maximum karakter sayısını 250 olarak belirliyoruz.

            modelBuilder.Entity<Category>().Property(p => p.LongDescription).HasMaxLength(600).IsOptional();
            // Max karakter sayısını 600 olarak tanımladık..

            modelBuilder.Entity<ProductCategoryMapping>().ToTable("ProductCategoryMapping");

            base.OnModelCreating(modelBuilder);
        }
    }
}
