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
    public class CustomersFactory
    {
        public static ICustomerRepository repo
        {
            get
            {
                IUnityContainer _container = new UnityContainer();
                _container.RegisterType(typeof(ICustomerRepository), typeof(CustomerRepository));
                ICustomerRepository obj = _container.Resolve<ICustomerRepository>();
                return obj;
            }
        } 

        public static List<CustomersModel> GetAll()
        { 
            Mapper.CreateMap<Customers, CustomersModel>();

            List<CustomersModel> lstCust = new List<CustomersModel>();

            foreach (var item in repo.GetAll())
            {
                CustomersModel dto = Mapper.Map<CustomersModel>(item);
                lstCust.Add(dto);
            }
            return lstCust;
        }
    }
}
