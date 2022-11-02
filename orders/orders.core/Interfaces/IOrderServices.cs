using orders.core.Models;
using orders.core.Requests;
using orders.core.Responses;

namespace orders.core.Interfaces
{
    public interface IOrderServices
    {

        Task<string> CreateOrder(Order request);

        Task<Order> GetOrderById(GetOrderByIdRequest request);

        Task<GetOrdersResponse> GetOrders();

        Task<bool> UpdateOrder(Order request);

        Task<bool> DeleteOrder(GetOrderByIdRequest request);
    }
}
