using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;
using Warehouse.Entities;

namespace Warehouse.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDatabaseRepository<Customer> _customerRepository;

        public CustomerController(IDatabaseRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerRepository.GetAll();

            return View(customers);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Customer customer = await _customerRepository.Get(id);
            return View(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            await _customerRepository.Update(customer);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            await _customerRepository.Add(customer);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await _customerRepository.Get(id);
            await _customerRepository.Delete(customer);

            return RedirectToAction("Index");
        }
    }
}