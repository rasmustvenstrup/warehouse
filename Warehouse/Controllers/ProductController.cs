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
        private readonly IImageRepository _imageRepository;

        public ProductController(IProductRepository productRepository, IImageRepository imageRepository)
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
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
                await _imageRepository.Add(file);
                product.ImageName = file.FileName;
            }
            
            await _productRepository.Add(product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _productRepository.Get(id);
            await _productRepository.Delete(product);
            _imageRepository.Delete(product.ImageName);

            return RedirectToAction("Index");
        }

        public IActionResult AddToShoppingCart()
        {
            throw new System.NotImplementedException();
        }
    }
}