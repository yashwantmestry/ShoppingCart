using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL
{
    public class NorthwindDataContext : DbContext
    {
        public NorthwindDataContext()
            : base("Northwind")
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
    }
}
