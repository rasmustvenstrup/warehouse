using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}