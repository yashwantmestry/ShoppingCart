using AutoMapper;
using Microsoft.Practices.Unity;
using ShoppingCart.BusinessObjects;
using ShoppingCart.Entities;
using ShoppingCart.Repositories;
using ShoppingCart.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BusinessFactories
{
    public class ProductFactory
    {

        public static IProductRepository prodRepository
        {
            get
            {
                IUnityContainer _container = new UnityContainer();
                _container.RegisterType(typeof(IProductRepository), typeof(ProductRepository));
                IProductRepository obj = _container.Resolve<IProductRepository>();
                return obj;
            }
        }

        //static IProductRepository prodRepository;
        //public ProductFactory(IProductRepository obj)
        //{
        //    prodRepository = obj;
        //}
        
        public static List<ProductModel> GetAllProducts()
        {
            //return prodRepository.GetAll().ToList<ProductModel>();

            Mapper.CreateMap<Product, ProductModel>();

            List<ProductModel> lstProductModel = new List<ProductModel>();
            foreach (var item in prodRepository.GetAll())
            {
                ProductModel dto = Mapper.Map<ProductModel>(item);
                lstProductModel.Add(dto);
            }
            return lstProductModel;
        }
    }
}
