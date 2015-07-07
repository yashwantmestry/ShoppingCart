using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ShoppingCart.Entities;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;

namespace ShoppingCart.DAL
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
            : base("name=ShoppingCartDBConnectionString")
        {
            Database.SetInitializer(new SilentDatabaseInitializer());
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var mappingType = typeof(EntityTypeConfiguration<>);

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => x.BaseType != null && x.BaseType.IsGenericType)
                .Where(x => x.BaseType.GetGenericTypeDefinition() == mappingType);

            foreach (var typeToRegister in typesToRegister)
            {
                dynamic mapping = Activator.CreateInstance(typeToRegister);
                modelBuilder.Configurations.Add(mapping);
            }
        }

        public DbSet<Product> Products { get; set; }
    }
}
