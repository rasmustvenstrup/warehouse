using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Warehouse.Contracts;

namespace Warehouse.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private const string ProductImagesPath = "wwwroot/ProductImages";

        public async Task Add(IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), ProductImagesPath, file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public void Delete(string imageName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), ProductImagesPath, imageName);

            File.Delete(path);
        }
    }
}
