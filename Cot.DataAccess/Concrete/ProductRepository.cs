using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Abstract;
using Cot.Core.Model;

namespace Cot.DataAccess.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CotDbContext db) : base(db)
        {
        }
    }
}
