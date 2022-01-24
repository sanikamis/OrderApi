using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using OrderBusinessLogic;
using OrderBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBLL _orderBLL;
        public OrderController(IOrderBLL orderBLL)
        {
            _orderBLL = orderBLL;
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(int orderId)
        {
            try
            {
                var order = _orderBLL.GetOrderById(orderId);
                if (order==null)
                {
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveOrder([FromBody] OrdersModel orderModel)
        {
            try
            {
                var model = _orderBLL.SaveOrder(orderModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message});
            }
        }

        
    }
}
