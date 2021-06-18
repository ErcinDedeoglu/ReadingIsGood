using System;
using Microsoft.EntityFrameworkCore;

namespace ReadingIsGood.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CategorySeed(modelBuilder);
            ProductSeed(modelBuilder);
            CustomerSeed(modelBuilder);
        }

        public DbSet<Data.Entity.User> Users{ get; set; }

        public DbSet<Data.Entity.Order> Orders{ get; set; }

        public DbSet<Data.Entity.OrderDetail> OrderDetails{ get; set; }

        public DbSet<Data.Entity.Customer> Customers{ get; set; }

        public DbSet<Data.Entity.Category> Categories{ get; set; }

        public DbSet<Data.Entity.Product> Products{ get; set; }

        private void CategorySeed(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 1,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Self-Help"
            });
            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 2,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Biographies"
            });
            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 3,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Business & Money"
            });
            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 4,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Children's Books"
            });
            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 5,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "History"
            });
            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 6,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Health, Fitness & Dieting"
            });
            modelBuilder.Entity<Data.Entity.Category>().HasData(new Data.Entity.Category
            {
                Id = 7,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Politics & Social Sciences"
            });
        }

        private void ProductSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 1,
                CategoryId = 1,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Color Joy Coloring Book: Perfectly Portable Pages",
                AmountOfStock = 13
            });
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 2,
                CategoryId = 1,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Four Agreements: A Practical Guide to Personal Freedom",
                AmountOfStock = 3
            });
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 3,
                CategoryId = 1,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Greenlights",
                AmountOfStock = 0
            });
            
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 4,
                CategoryId = 2,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Atatürk",
                AmountOfStock = 1881
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 5,
                CategoryId = 2,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "12 Years a Slave",
                AmountOfStock = 55
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 6,
                CategoryId = 2,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Running on Red Dog Road: And Other Perils of an Appalachian",
                AmountOfStock = 233
            });
            
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 7,
                CategoryId = 3,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Book on Sales and Marketing: Expert Marketing for the People",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 8,
                CategoryId = 3,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "HBR's 10 Must Reads on Sales",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 9,
                CategoryId = 3,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Sales 101: From Finding Leads and Closing Techniques to Retaining Customers and Growing Your Business",
                AmountOfStock = 233
            });
            
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 10,
                CategoryId = 4,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Lost on a Mountain in Maine",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 11,
                CategoryId = 4,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Boy on the Wooden Box: How the Impossible Became Possible",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 12,
                CategoryId = 4,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "A Long Walk to Water: Based on a True Story",
                AmountOfStock = 233
            });
            
            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 13,
                CategoryId = 5,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Turkish War of Independence: A Military History, 1919-1923",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 14,
                CategoryId = 5,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Happiest Man on Earth",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 15,
                CategoryId = 5,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Wild: From Lost to Found on the Pacific Crest Trail",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 16,
                CategoryId = 6,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Good Carb Cookbook: Secrets of Eating Low on the Glycemic Index",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 17,
                CategoryId = 6,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "The Four Agreements: A Practical Guide to Personal Freedom",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 18,
                CategoryId = 6,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Quiet: The Power of Introverts in a World That Can't Stop Talking",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 19,
                CategoryId = 7,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Spilled Milk: Based on a true story",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 20,
                CategoryId = 7,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "Exposing U.S. Government Policies On Extraterrestrial Life: The Challenge Of Exopolitics",
                AmountOfStock = 233
            });

            modelBuilder.Entity<Data.Entity.Product>().HasData(new Data.Entity.Product
            {
                Id = 21,
                CategoryId = 7,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Name = "On Death And Dying",
                AmountOfStock = 233
            });
        }
        
        private void CustomerSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data.Entity.Customer>().HasData(new Data.Entity.Customer
            {
                Id = 1,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                FirstName = "Erçin",
                LastName = "Dedeoğlu"
            });

            modelBuilder.Entity<Data.Entity.Customer>().HasData(new Data.Entity.Customer
            {
                Id = 2,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                FirstName = "Aylin",
                LastName = "Dedeoğlu"
            });

            modelBuilder.Entity<Data.Entity.Customer>().HasData(new Data.Entity.Customer
            {
                Id = 3,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                FirstName = "Ata",
                LastName = "Dedeoğlu"
            });
        }
    }
}