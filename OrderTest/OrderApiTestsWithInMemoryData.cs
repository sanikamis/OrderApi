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
    public class OrderApiTestsWithInMemoryData
    {        
        private OrderController _orderController;
        private IOrderBLL _orderBLL;
        public OrderApiTestsWithInMemoryData()
        {
            _orderBLL = new InMemoryOrderBLL();
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
        public void GetOrderById_ExistingOrder()
        {
            var okResult = _orderController.GetOrderById(1) as OkObjectResult;
            // Assert
            Assert.IsType<OrdersModel>(okResult.Value);
            Assert.Equal(1, (okResult.Value as OrdersModel).OrderId);
        }

        [Fact]
        public void SaveOrder()
        {
            OrdersModel ordersModel = new OrdersModel
            {
                Products = new List<ProductsModel>
                   {
                       new ProductsModel{ ProductType = ProductTypes.photoBook, Quantity=1 }
                   }
            };
            var okResult = _orderController.SaveOrder(ordersModel) as OkObjectResult;
            // Assert
            Assert.IsType<OrdersModel>(okResult.Value);
            Assert.Equal(ordersModel.Products, (okResult.Value as OrdersModel).Products);
        }

    }
}
