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

        public async Task<string>CreateOrder(Order request)
        {
            try 
            {
                var guid = Guid.NewGuid();
                request.Id = guid.ToString();
                request.CreatedDate = DateTime.Now;
                return await _orderAdapter.CreateOrder(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order>GetOrderById(GetOrderByIdRequest request)
        {
            try
            {
                return await _orderAdapter.GetOrderById(request);
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

        public async Task<GetOrdersResponse> GetOrderByType(GetOrderByTypeRequest request)
        {
            var response = new GetOrdersResponse();
            var orderList = await _orderAdapter.GetOrders();
            response.Orders = orderList.Where(x => x.Type == request.Type).ToList(); ;
            return response;
        }


        public async Task<bool>UpdateOrder(Order request)
        {
            try
            {
                return await _orderAdapter.UpdateOrder(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool>DeleteOrder(GetOrderByIdRequest request)
        {
            try
            {
                return await _orderAdapter.DeleteOrder(request);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }    
}