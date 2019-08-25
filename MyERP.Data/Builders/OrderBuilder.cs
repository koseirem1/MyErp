using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
   public class OrderBuilder
    {
        public OrderBuilder(EntityTypeConfiguration<Order> builder)
        {
            builder.HasRequired(a => a.Customer).WithMany(b => b.Orders).HasForeignKey(a => a.CustomerId);
            builder.Property(b => b.Created).HasMaxLength(100);
            builder.HasRequired(a => a.Product).WithMany(b => b.Orders).HasForeignKey(a => a.ProductId
            );
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasOptional(a => a.Tax).WithMany(b => b.Orders).HasForeignKey(a => a.TaxId);
           
        }
    }
}

