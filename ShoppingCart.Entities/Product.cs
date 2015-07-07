using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }

    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            HasKey(x => x.ProductId);

            Property(x => x.ProductId);

            Property(x => x.ProductName)
                .HasColumnName("ProductName")
                .HasMaxLength(50)
                .IsOptional(); 

        }
    }
}
