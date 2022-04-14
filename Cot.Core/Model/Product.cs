using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cot.Core.Model
{
    public class Product
    {
        public Product()
        {
            CustomerOrders = new List<CustomerOrder>();
        }
        public int Id { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual List<CustomerOrder>? CustomerOrders { get; set; }
    }
}
