using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cot.Core.Model
{
    public class Customer
    {
        public Customer()
        {
            CustomerOrders = new List<CustomerOrder>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual List<CustomerOrder>? CustomerOrders { get; set; }

    }
}
