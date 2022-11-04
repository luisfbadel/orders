using Microsoft.AspNetCore.Mvc;
using orders.core.Interfaces;
using orders.core.Models;
using orders.core.Requests;

namespace orders.api.Controllers
{
    [ApiController]
    public class OrderController : Controller
    {
        #region Private Properties

        private readonly IOrderServices _orderServices;
        private const string ORDERNOTFOUND = "Order was not found";

        #endregion

        #region Constructor
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderServices"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices ?? throw new ArgumentNullException(nameof(orderServices));
        }

        #endregion

        [Route("api/v1/orders/create-order")]
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
        {
            if(ModelState.IsValid)
            {
                var response = await _orderServices.CreateOrder(request);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("api/v1/orders/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetOrderById([FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.GetOrderById(id);
                if(response != null) return Ok(response);
                else return BadRequest(ORDERNOTFOUND);

            }
            else
            {
                return BadRequest();
            }
        }

        [Route("api/v1/orders/get-by-type/{type}")]
        [HttpGet]
        public async Task<IActionResult> GetOrderByType([FromRoute] int type)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.GetOrderByType(type);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("api/v1/orders")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderServices.GetOrders();
            return Ok(response);
        }

        [Route("api/v1/orders/update-order")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.UpdateOrder(request);
                if(response) return Ok(response);
                else return BadRequest(ORDERNOTFOUND);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("api/v1/orders/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromRoute] string id)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.DeleteOrder(id);
                if (response) return Ok(response);
                else return BadRequest(ORDERNOTFOUND);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}