using OrderBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusinessLogic
{
    public class OrderFunctions
    {
        public static void SetBinWidth(OrdersModel orderModel)
        {
            orderModel.Products.ToList().ForEach(p => ProductFunctions.SetWidth(p));
            orderModel.RequiredBinWidth = orderModel.Products.Sum(p => p.Width);
        }

    }
}
