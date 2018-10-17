using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;
using Warehouse.Entities;

namespace Warehouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDatabaseRepository<Order> _orderRepository;

        public OrderController(IDatabaseRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAll();

            return View(orders);
        }
    }
}