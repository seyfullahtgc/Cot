using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Model;

namespace Cot.Core.Services
{
    public interface ICustomerOrderService:IService<CustomerOrder>
    {
        Task<IEnumerable<CustomerOrder>> GetByOrderIdAsync(int orderId);
    }
}
