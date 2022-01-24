using OrderBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusinessLogic
{
    public class InMemoryOrderBLL : IOrderBLL
    {
        private readonly List<OrdersModel> _orders;

        public InMemoryOrderBLL()
        {
            _orders = GenerateOrders();          
        }

        private List<OrdersModel> GenerateOrders()
        {
            return new List<OrdersModel>()
            {
               new OrdersModel{
                   OrderId = 1,
                   Products = new List<ProductsModel>
                   {
                       new ProductsModel{ ProductId=1, ProductType = ProductTypes.photoBook, Quantity=1, Width = Constants.ProductWidth_PhotoBook }
                   },
                   RequiredBinWidth = Constants.ProductWidth_PhotoBook
               },
               new OrdersModel{
                   OrderId = 2,
                   Products = new List<ProductsModel>
                   {
                       new ProductsModel{ ProductId=2, ProductType = ProductTypes.canvas, Quantity=2, Width = Constants.ProductWidth_Canvas*2 }
                   },
                   RequiredBinWidth = Constants.ProductWidth_Canvas*2
               },
               new OrdersModel{
                   OrderId = 3,
                   Products = new List<ProductsModel>
                   {
                       new ProductsModel{ ProductId=3, ProductType = ProductTypes.cards, Quantity=1, Width = Constants.ProductWidth_Cards },
                       new ProductsModel{ ProductId=4, ProductType = ProductTypes.photoBook, Quantity=3, Width = Constants.ProductWidth_PhotoBook },
                   },
                   RequiredBinWidth = Constants.ProductWidth_Cards + Constants.ProductWidth_PhotoBook * 3
               },
                new OrdersModel{
                   OrderId = 4,
                   Products = new List<ProductsModel>
                   {
                       new ProductsModel{ ProductId=5, ProductType = ProductTypes.mug, Quantity=5, Width = Constants.ProductWidth_Mug*2 }
                   },
                   RequiredBinWidth = Constants.ProductWidth_Mug * 2
               }
            };
        }

        public OrdersModel GetOrderById(int orderId)
        {
            return _orders.Where(o => o.OrderId == orderId).FirstOrDefault();
        }

        public OrdersModel SaveOrder(OrdersModel orderModel)
        {
            orderModel.OrderId = _orders.Max(o => o.OrderId) + 1;
            _orders.Add(orderModel);
            return orderModel;
        }
    }
}
