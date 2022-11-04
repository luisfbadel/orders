using orders.core.Models;

namespace orders.core.Interfaces
{
    public interface IOrderAdapter
    {
        Task<string> CreateOrder(Order request);

        Task<Order> GetOrderById(string id);

        Task<List<Order>> GetOrders();

        Task<bool> UpdateOrder(Order request);

        Task<bool> DeleteOrder(string id);
    }
}
