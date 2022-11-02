using orders.core.Models;
using orders.core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace orders.core.Interfaces
{
    public interface IOrderAdapter
    {
        Task<string> CreateOrder(Order request);

        Task<Order> GetOrderById(GetOrderByIdRequest request);

        Task<List<Order>> GetOrders();

        Task<bool> UpdateOrder();

        Task<bool> DeleteOrder(GetOrderByIdRequest request);
    }
}
