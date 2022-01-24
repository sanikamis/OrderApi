using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDataAccess.Repository.Entities
{
    public class Orders
    {
        public Orders()
        {
            Products = new List<Products>();
        }

        [Key]
        public int OrderId { get; set; }

        public List<Products> Products { get; set; }

        public float RequiredBinWidth { get;set; } 

    }
}
