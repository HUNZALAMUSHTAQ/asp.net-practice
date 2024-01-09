using Microsoft.EntityFrameworkCore;
using Shopping.Data;
using Shopping.Dtos;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Service
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        public OrderService(DataContext context)
        {
            _context = context;
            
        }
        public async Task<CreateOrderDto> CreateOrder(CreateOrderDto order)
        {
            var a = new Order { Name = order.Name };
            _context.Orders.Add(a);
            await _context.SaveChangesAsync();
            var orderDto = new CreateOrderDto { Name = order.Name, Id = a.Id};
            return orderDto;
        }

            public Order GetOrder(int id)
            {

            return _context.Orders
   .Include(o => o.Products)  // Include the Products related to the Order
   .FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetOrders()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }
    }
}
