using ShoppingCart.DAL;
using ShoppingCart.Entities;
using ShoppingCart.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ShoppingCartContext ctx;

        public ProductRepository()
        {
            ctx = new ShoppingCartContext();
        }

        public List<Product> GetAll()
        {
            return ctx.Products.ToList();
        }
    }
}
