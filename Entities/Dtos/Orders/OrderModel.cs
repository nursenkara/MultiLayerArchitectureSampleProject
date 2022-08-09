using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Orders
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        //public List<Product> Products { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
