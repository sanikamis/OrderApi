using System.ComponentModel.DataAnnotations;

namespace OrderDataAccess.Repository.Entities
{

    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public ProductType ProductType { get; set; }
        public int Quantity { get; set; }
        public float Width { get;set; }
    }


}