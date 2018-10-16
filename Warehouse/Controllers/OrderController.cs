using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;

namespace Warehouse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
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