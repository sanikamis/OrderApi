using OrderDataAccess;
using OrderDataAccess.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OrderTest
{
    public class OrderDALTests
    {
        private OrderDAL _orderDAL;

        public OrderDALTests()
        {
            _orderDAL = new OrderDAL();
        }
        [Fact]
        public void OrderNotFound()
        {
            var orderEntity = _orderDAL.GetOrderById(0);
            Assert.Null(orderEntity);
        }
    }
}
