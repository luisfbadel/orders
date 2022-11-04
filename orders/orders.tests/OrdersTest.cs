using Moq;
using order.application;
using orders.api.Controllers;
using orders.core.Interfaces;
using orders.core.Models;

namespace orders.tests
{
    public class OrdersTest
    {
        #region Private Properties

        protected OrderController orderController;
        protected OrderService orderService;
        protected Mock<IOrderAdapter> mockOrderAdapter = new Mock<IOrderAdapter>();
        protected Mock<IOrderServices> mockOrderServices = new Mock<IOrderServices>();

        #endregion

        #region Constructor
        
        public OrdersTest()
        {
            mockOrderAdapter.Setup(x => x.GetOrderById(It.IsAny<string>())).Returns(Task.FromResult(_getOrderByIdResponse(IdRequest())));
            mockOrderServices.Setup(x => x.GetOrderById(It.IsAny<string>())).Returns(Task.FromResult(_getOrderByIdResponse(IdRequest())));
            orderService = new OrderService(mockOrderAdapter.Object);
            orderController = new OrderController(mockOrderServices.Object);
        }

        #endregion

        #region Private Methods

        private Order _getOrderByIdResponse(string id)
        {
            var order = new Order()
            {
                Id = id,
                CreatedByUsername = "testUser",
                CreatedDate = DateTime.Now,
                CustomerName = "testUserName",
                Type = 1
            };
            return order;
        }
        private string IdRequest()
        {
            return new Guid().ToString();
        }

        #endregion

        [Fact]
        public void ValidGetOrderById()
        {
            var response = orderController.GetOrderById(IdRequest());
            Assert.NotNull(response);
            Assert.True(response.IsCompletedSuccessfully);
        }
    }
}