using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;
using Warehouse.Entities;

namespace Warehouse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _unitOfWork.ProductRepository.GetAll();

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
                await _unitOfWork.ImageRepository.Add(file);
                product.ImageName = file.FileName;
            }
            
            _unitOfWork.ProductRepository.Add(product);
            await _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _unitOfWork.ProductRepository.Get(id);
            _unitOfWork.ProductRepository.Delete(product);

            if (!string.IsNullOrEmpty(product.ImageName))
            {
                _unitOfWork.ImageRepository.Delete(product.ImageName);
            }

            await _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult AddToShoppingCart()
        {
            throw new System.NotImplementedException();
        }
    }
}