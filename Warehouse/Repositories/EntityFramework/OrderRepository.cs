using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Contracts;
using Warehouse.DbContexts;
using Warehouse.Entities;

namespace Warehouse.Repositories.EntityFramework
{
    public class OrderRepository : IDatabaseRepository<Order>
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task Add(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders
                .Include(order => order.Products)
                .SingleAsync(customer => customer.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders
                .Include(order => order.Products)
                .ToListAsync();
        }
    }
}