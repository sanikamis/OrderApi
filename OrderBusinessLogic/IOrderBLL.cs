using OrderBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusinessLogic
{
    public interface IOrderBLL
    {
        public OrdersModel GetOrderById(int orderId);

        public OrdersModel SaveOrder(OrdersModel orderModel);
    }
}
