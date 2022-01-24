using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace OrderBusinessLogic.Models
{

    public class ProductsModel
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public int ProductId { get; set; }

        public ProductTypes ProductType { get; set; }

        public int Quantity { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public float Width { get;set; }

        

    }


}