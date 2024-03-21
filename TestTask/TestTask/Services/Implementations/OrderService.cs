using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : Generic<Order>, IOrderService
    {
        public OrderService(ApplicationDbContext context) : base(context) 
        {
            
        }

        public async Task<Order> GetOrder()
        {
            List<Order> allOrders = _context.Orders.ToList();
            
            int maxPrice = 0;
            int orderId = 0;
            foreach (var item in allOrders)
            {
                if (maxPrice < item.Price) 
                {
                    maxPrice = item.Price;
                    orderId = item.Id;
                }

            }

            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<List<Order>> GetOrders()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            return (List<Order>)orders.Where(or => or.Quantity > 10);
        }
    }
}
