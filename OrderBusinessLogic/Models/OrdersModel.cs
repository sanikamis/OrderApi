using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderBusinessLogic.Models
{
    public class OrdersModel
    {
        public OrdersModel()
        {
            Products = new List<ProductsModel>();
        }

        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int OrderId { get; set; }

        public List<ProductsModel> Products { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public float RequiredBinWidth { get;set; } 

    }
}
