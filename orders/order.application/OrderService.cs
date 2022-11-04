using orders.core.Interfaces;
using orders.core.Models;
using orders.core.Requests;
using orders.core.Responses;

namespace order.application
{
    public class OrderService : IOrderServices
    {
        #region Private Properties

        private readonly IOrderAdapter _orderAdapter;

        #endregion

        #region Constructor

        /// <summary>
        /// Controller
        /// </summary>
        /// <param name="context"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public OrderService(IOrderAdapter orderAdapter)
        {
            _orderAdapter = orderAdapter ?? throw new ArgumentNullException(nameof(orderAdapter));
        }

        #endregion

        public async Task<string>CreateOrder(CreateOrderRequest request)
        {
            try 
            {
                var order = new Order();
                var guid = Guid.NewGuid();
                order.Id = guid.ToString();
                order.CreatedDate = DateTime.Now;
                order.CreatedByUsername = request.CreatedByUsername;
                order.CustomerName = request.CustomerName;
                order.Type = request.Type;
                return await _orderAdapter.CreateOrder(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order>GetOrderById(string id)
        {
            try
            {
                return await _orderAdapter.GetOrderById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetOrdersResponse>GetOrders()
        {
            var response = new GetOrdersResponse();
            try
            {
                response.Orders = await _orderAdapter.GetOrders();
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetOrdersResponse> GetOrderByType(int type)
        {
            var response = new GetOrdersResponse();
            var orderList = await _orderAdapter.GetOrders();
            response.Orders = orderList.Where(x => x.Type == type).ToList(); ;
            return response;
        }


        public async Task<bool>UpdateOrder(UpdateOrderRequest request)
        {
            try
            {
                var order = new Order();
                order.CustomerName = request.CustomerName;
                order.Id = request.Id;
                order.Type = request.Type;
                return await _orderAdapter.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool>DeleteOrder(string id)
        {
            try
            {
                return await _orderAdapter.DeleteOrder(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }    
}