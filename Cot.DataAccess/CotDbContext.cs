using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cot.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Cot.DataAccess
{
    public class CotDbContext : DbContext
    {
        public CotDbContext(DbContextOptions<CotDbContext> options) : base(options)
        {

        }
        
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerOrder> CustomerOrder { get; set; }
    }
    
}
