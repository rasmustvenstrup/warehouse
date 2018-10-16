using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;
using Warehouse.Entities;

namespace Warehouse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly string _productImagesPath = "ProductImages";

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productRepository.GetAll();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile file)
        {
            if (file != null && file.Length != 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _productImagesPath, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                product.ImageName = file.FileName;
            }
            
            await _productRepository.Add(product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Buy()
        {

        }
    }
}