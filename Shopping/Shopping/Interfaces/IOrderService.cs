using Shopping.Dtos;
using Shopping.Models;

namespace Shopping.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order GetOrder(int id);
        Task<CreateOrderDto>  CreateOrder(CreateOrderDto order);
    }
}
