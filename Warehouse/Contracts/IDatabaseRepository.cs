using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Entities;

namespace Warehouse.Contracts
{
    public interface IDatabaseRepository<T> where T : Entity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}