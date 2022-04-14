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
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repo) : base(unitOfWork, repo)
        {
        }
    }
}
