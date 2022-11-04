using orders.core.Models;
using orders.core.Requests;
using orders.core.Responses;

namespace orders.core.Interfaces
{
    public interface IOrderServices
    {
       
        Task<string> CreateOrder(CreateOrderRequest request);

        Task<Order> GetOrderById(string id);

        Task<GetOrdersResponse> GetOrderByType(int type);

        Task<GetOrdersResponse> GetOrders();

        Task<bool> UpdateOrder(UpdateOrderRequest request);

        Task<bool> DeleteOrder(string id);
    }
}
