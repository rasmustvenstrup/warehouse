using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;
using Warehouse.Entities;

namespace Warehouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _unitOfWork.OrderRepository.GetAll();

            return View(orders);
        }

        public async Task<IActionResult> Create()
        {
            var order = new Order();
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.GetAll();

            foreach (Product product in products)
            {
                order.AddProduct(product);
            }

            _unitOfWork.OrderRepository.Add(order);

            return RedirectToAction("Index");
        }
    }
}