using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DAL.ModelMap
{
    public class CustomerModelMap : EntityTypeConfiguration<Customers>
    {
        public CustomerModelMap()
        {
            ToTable("Customers");
            HasKey(x => x.CustomerID);

            Property(x => x.CustomerID)
                .HasColumnName("CustomerID")
                .HasMaxLength(5);
            Property(x => x.CompanyName)
                .HasColumnName("CompanyName")
                .HasMaxLength(40);
            Property(x => x.ContactName)
                .HasColumnName("ContactName")
                .HasMaxLength(30);
            Property(x => x.ContactTitle)
                .HasColumnName("ContactTitle")
                .HasMaxLength(30);
            Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(60);
            Property(x => x.City)
                .HasColumnName("City")
                .HasMaxLength(15);
            Property(x => x.Region)
                .HasColumnName("Region")
                .HasMaxLength(15);
            Property(x => x.PostalCode)
                .HasColumnName("PostalCode")
                .HasMaxLength(10);
            Property(x => x.Country)
                .HasColumnName("Country")
                .HasMaxLength(15);
            Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasMaxLength(24);
            Property(x => x.Fax)
                .HasColumnName("Fax")
                .HasMaxLength(24);
        }
    }
}
