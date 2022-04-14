using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Model;

namespace Cot.Core.Abstract
{
    public interface ICustomerOrderRepository : IRepository<CustomerOrder>
    {
        Task<IEnumerable<CustomerOrder>> GetByOrderIdAsync(int orderId);
    }
}
