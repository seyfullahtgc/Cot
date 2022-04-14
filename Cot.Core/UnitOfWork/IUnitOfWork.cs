using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Abstract;

namespace Cot.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICustomerRepository Customer { get; }
        ICustomerOrderRepository CustomerOrder { get; }

        Task CommitAsync();
        void Commit();
    }
}
