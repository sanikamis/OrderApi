using AutoMapper;
using OrderBusinessLogic.Models;
using OrderDataAccess;
using OrderDataAccess.Repository.Entities;
using System;

namespace OrderBusinessLogic
{
    public class OrderBLL : IOrderBLL
    {
        private readonly OrderDAL _orderDAL;
        private readonly Mapper _mapper;
        public OrderBLL()
        {
            _orderDAL = new OrderDAL();
            var mapperConfig = new MapperConfiguration(cfg => { 
                cfg.CreateMap<Orders, OrdersModel>().ReverseMap();
                cfg.CreateMap<Products, ProductsModel>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }
        public OrdersModel GetOrderById(int orderId)
        {
            var orderEntity = _orderDAL.GetOrderById(orderId);
            return _mapper.Map<Orders, OrdersModel>(orderEntity);
        }

        public OrdersModel SaveOrder(OrdersModel orderModel)
        {
            if (orderModel.Products.Exists(p=>p.Quantity<1))
            {
                throw new Exception("Quantity cannot be less than 1");
            }
            if (orderModel.Products.Exists(p => p.ProductId != 0))
            {
                throw new Exception("ProductId is not allowed in the request");
            }
            OrderFunctions.SetBinWidth(orderModel);
            var orderEntity = _mapper.Map<OrdersModel, Orders>(orderModel);
            orderEntity = _orderDAL.SaveOrder(orderEntity);
            return _mapper.Map<Orders, OrdersModel>(orderEntity);
        }
    }
}
