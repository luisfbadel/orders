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

        [Route("orders/CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(Order request)
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

        [Route("orders/GetOrderById")]
        [HttpGet]
        public async Task<IActionResult> GetOrderById(GetOrderByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.GetOrderById(request);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("orders/GetOrders")]
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var response = await _orderServices.GetOrders();
            return Ok(response);
        }

        [Route("orders/UpdateOrder")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(Order request)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.UpdateOrder(request);
                if(response) return Ok(response);
                else return BadRequest("Order was not found");
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("orders/DeleteOrder")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(GetOrderByIdRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _orderServices.DeleteOrder(request);
                if (response) return Ok(response);
                else return BadRequest("Order was not found");
            }
            else
            {
                return BadRequest();
            }
        }

    }
}