using Microsoft.EntityFrameworkCore;
using Warehouse.Entities;

namespace Warehouse.DbContexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasOne(bc => bc.Order)
                .WithMany(b => b.Products)
                .HasForeignKey(bc => bc.OrderId);
        }
    }
}