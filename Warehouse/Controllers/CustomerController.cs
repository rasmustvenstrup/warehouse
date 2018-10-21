using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Contracts;
using Warehouse.Entities;

namespace Warehouse.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAll();

            return View(customers); 
        }

        public async Task<IActionResult> Edit(int id)
        {
            Customer customer = await _unitOfWork.CustomerRepository.Get(id);

            return View(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            _unitOfWork.CustomerRepository.Update(customer);
            await _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await _unitOfWork.CustomerRepository.Get(id);
            _unitOfWork.CustomerRepository.Delete(customer);
            await _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}