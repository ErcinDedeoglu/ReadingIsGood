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
        }

        //public DbSet<Data.Entity.ToDeeplink> ToDeeplinks{ get; set; }

        //public DbSet<Data.Entity.ToWebURL> ToWebUrls{ get; set; }
    }
}