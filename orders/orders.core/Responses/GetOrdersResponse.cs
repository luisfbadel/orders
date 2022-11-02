using orders.core.Models;

namespace orders.core.Responses
{
    public class GetOrdersResponse
    {
        public GetOrdersResponse()
        {
            Orders = new List<Order>();
        }
        public List<Order> Orders { get; set; }
    }
}
