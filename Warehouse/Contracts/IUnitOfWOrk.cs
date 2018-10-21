using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface IUnitOfWork
    {
        IDatabaseRepository<Product> ProductRepository { get; }
        IDatabaseRepository<Customer> CustomerRepository { get; }
        IDatabaseRepository<Order> OrderRepository { get; }
        IImageRepository ImageRepository { get; }

        Task Commit();
    }
}