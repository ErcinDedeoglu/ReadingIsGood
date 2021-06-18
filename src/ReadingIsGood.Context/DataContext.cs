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
        }

        public DbSet<Data.Entity.User> Users{ get; set; }

        public DbSet<Data.Entity.Order> Orders{ get; set; }

        public DbSet<Data.Entity.Customer> Customers{ get; set; }

        public DbSet<Data.Entity.Category> Categories{ get; set; }

        public DbSet<Data.Entity.Product> Products{ get; set; }
    }
}