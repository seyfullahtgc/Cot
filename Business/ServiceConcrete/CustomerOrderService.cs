using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Abstract;
using Cot.Core.Model;
using Cot.Core.Services;
using Cot.Core.UnitOfWork;

namespace Cot.Business.ServiceConcrete
{
    public class CustomerOrderService : Service<CustomerOrder>, ICustomerOrderService
    {
        public CustomerOrderService(IUnitOfWork unitOfWork, IRepository<CustomerOrder> repo) : base(unitOfWork, repo)
        {
        }


        public async Task<IEnumerable<CustomerOrder>> GetByOrderIdAsync(int orderId)
        {
            return await _unitOfWork.CustomerOrder.GetByOrderIdAsync(orderId);

        }
    }
}
