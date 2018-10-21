using System.Threading.Tasks;
using Warehouse.Contracts;
using Warehouse.DbContexts;
using Warehouse.Entities;

namespace Warehouse.Repositories.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            ProductRepository = new ProductRepository(_context);
            CustomerRepository = new CustomerRepository(_context);
            OrderRepository = new OrderRepository(_context);
            ImageRepository = new ImageRepository();
        }

        public IDatabaseRepository<Product> ProductRepository { get; private set; }
        public IDatabaseRepository<Customer> CustomerRepository { get; private set; }
        public IDatabaseRepository<Order> OrderRepository { get; private set; }
        public IImageRepository ImageRepository { get; }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}