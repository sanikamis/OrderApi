using Microsoft.EntityFrameworkCore;
using OrderDataAccess.Repository;
using OrderDataAccess.Repository.Entities;
using System;
using System.Linq;

namespace OrderDataAccess
{
    public class OrderDAL
    {
        public Orders GetOrderById(int orderId)
        {
            Orders order;
            try
            {
                var db = new OrderDbContext();
                order = db.Orders.Where(o => o.OrderId == orderId).Include(o => o.Products).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return order;
        }

        public Orders SaveOrder(Orders order)
        { 
            var db = new OrderDbContext();
            try
            {               
                db.Add(order);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
            return order;
        }
    }
}
