using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface ICustomerRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Delete(Customer customer);
        Task<Customer> Get(int id);
        Task<IEnumerable<Customer>> GetAll();
    }
}
