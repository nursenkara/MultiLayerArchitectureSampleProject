using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.OrderProducts
{
    public class OrderProductsListModel
    {
        public int OrderProductId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }
    }
}
