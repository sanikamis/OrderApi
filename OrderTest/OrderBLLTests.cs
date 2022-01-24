using OrderBusinessLogic;
using OrderBusinessLogic.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace OrderTest
{
    public class OrderBLLTests
    {
        private OrderBLL _orderBLL;

        public OrderBLLTests()
        {
            _orderBLL = new OrderBLL();
        }

        [Fact]
        public void SetRequiredBinWidth_OnePhotoBook()
        {
            OrdersModel ordersModel = new OrdersModel();
            ordersModel.Products.Add(
                new ProductsModel
                {
                    ProductType = ProductTypes.photoBook,
                    Quantity = 1
                });
            OrderFunctions.SetBinWidth(ordersModel);
            Assert.Equal(ordersModel.RequiredBinWidth, Constants.ProductWidth_PhotoBook);
        }

        [Fact]
        public void SetRequiredBinWidth_2Cards()
        {
            OrdersModel ordersModel = new OrdersModel();
            ordersModel.Products.Add(
                new ProductsModel
                {
                    ProductType = ProductTypes.cards,
                    Quantity = 2
                });
            OrderFunctions.SetBinWidth(ordersModel);
            Assert.Equal(ordersModel.RequiredBinWidth, Constants.ProductWidth_Cards*2);
        }

        [Fact]
        public void SetRequiredBinWidth_4Mugs()
        {
            OrdersModel ordersModel = new OrdersModel();
            ordersModel.Products.Add(
                new ProductsModel
                {
                    ProductType = ProductTypes.mug,
                    Quantity = 4
                });
            OrderFunctions.SetBinWidth(ordersModel);
            Assert.Equal(ordersModel.RequiredBinWidth, Constants.ProductWidth_Mug);
        }
        
        [Fact]
        public void SetRequiredBinWidth_5Mugs()
        {
            OrdersModel ordersModel = new OrdersModel();
            ordersModel.Products.Add(
                new ProductsModel
                {
                    ProductType = ProductTypes.mug,
                    Quantity = 5
                });
            OrderFunctions.SetBinWidth(ordersModel);
            Assert.Equal(ordersModel.RequiredBinWidth, Constants.ProductWidth_Mug*2);
        }

        [Fact]
        public void OrderNotFound()
        {
            var orderModel = _orderBLL.GetOrderById(0);
            Assert.Null(orderModel);
        }
        
    }
}
