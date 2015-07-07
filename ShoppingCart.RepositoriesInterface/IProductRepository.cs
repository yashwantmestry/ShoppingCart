using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.RepositoriesInterface
{
    public interface IProductRepository
    {
        List<Product> GetAll();
    }
}
