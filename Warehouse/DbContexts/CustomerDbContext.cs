using Microsoft.EntityFrameworkCore;
using Warehouse.Entities;

namespace Warehouse.DbContexts
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
