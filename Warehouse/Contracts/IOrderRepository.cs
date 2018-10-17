using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface IOrderRepository : IDatabaseRepository<Order>
    {
    }
}