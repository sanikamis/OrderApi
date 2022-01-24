using Microsoft.AspNetCore.Mvc;
using OrderApi.Controllers;
using OrderBusinessLogic;
using OrderBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTest
{
    public class OrderApiTests
    {
        private OrderController _orderController;
        private IOrderBLL _orderBLL;

        public OrderApiTests()
        {
            _orderBLL = new OrderBLL();
            _orderController = new OrderController(_orderBLL);
        }

        [Fact]
        public void NotFound()
        {
            var notFoundResult = _orderController.GetOrderById(0);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void BadRequest_OrderId() 
        {
            var ordersModel = new OrdersModel() { OrderId = 1 };
            var badRequestResult = _orderController.SaveOrder(ordersModel);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }

        [Fact]
        public void BadRequest_Quantity()
        {
            var ordersModel = new OrdersModel
            {
                Products = new List<ProductsModel>
                   {
                       new ProductsModel{ ProductType = ProductTypes.photoBook, Quantity=0 }
                   }
            };
            var badRequestResult = _orderController.SaveOrder(ordersModel);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badRequestResult);
        }
    }
}
