using orders.core.Models;
using orders.core.Requests;

namespace orders.core.Interfaces
{
    public interface IOrderAdapter
    {
        Task<string> CreateOrder(Order request);

        Task<Order> GetOrderById(GetOrderByIdRequest request);

        Task<List<Order>> GetOrders();

        Task<bool> UpdateOrder(Order request);

        Task<bool> DeleteOrder(GetOrderByIdRequest request);
    }
}
