using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Abstract;
using Cot.Core.UnitOfWork;
using Cot.DataAccess.Concrete;

namespace Cot.DataAccess.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CotDbContext _db;
        private ProductRepository _productRepository;
        private CustomerRepository _customerRepository;
        private CustomerOrderRepository _customerOrderRepository;
        public IProductRepository Product => _productRepository ??= new ProductRepository(_db);

        public ICustomerRepository Customer => _customerRepository ??= new CustomerRepository(_db);
        
        public ICustomerOrderRepository CustomerOrder => _customerOrderRepository ??= new CustomerOrderRepository(_db);

        public UnitOfWork(CotDbContext cotDbContext)
        {
            _db = cotDbContext;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
