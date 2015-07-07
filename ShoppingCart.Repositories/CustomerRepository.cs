using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.DAL;
using ShoppingCart.RepositoriesInterface;
using ShoppingCart.Entities;

namespace ShoppingCart.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private NorthwindDataContext ctx;
        public CustomerRepository()
        {
            ctx = new NorthwindDataContext();
        }

        public List<Customers> GetAll()
        { 
            return ctx.Set<Customers>().ToList();
        }
    }
}
