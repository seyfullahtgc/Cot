using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Abstract;
using Cot.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Cot.DataAccess.Concrete
{
    public class CustomerOrderRepository : Repository<CustomerOrder>, ICustomerOrderRepository
    {
        private CotDbContext cotDbContext {get=>(_db as CotDbContext)!;}
        public CustomerOrderRepository(CotDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<CustomerOrder>> GetByOrderIdAsync(int orderId)
        {
            return (await cotDbContext.CustomerOrder.Include(s => s.Product).Where(s=>s.OrderId==orderId).ToListAsync())!;
        }
    }
}
