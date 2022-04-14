using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cot.Core.Model
{
    public class CustomerOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
