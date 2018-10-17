using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface IDatabaseRepository<T> where T : Entity
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}