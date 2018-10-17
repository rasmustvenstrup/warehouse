using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Warehouse.Contracts
{
    public interface IImageRepository
    {
        Task Add(IFormFile file);
        void Delete(string imageName);
    }
}