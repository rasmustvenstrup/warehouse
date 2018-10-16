using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface IOrderRepository
    {
        Task Add(Order order);
        Task Update(Order order);
        Task Delete(Order order);
        Task<Order> Get(int id);
        Task<IEnumerable<Order>> GetAll();
    }
}