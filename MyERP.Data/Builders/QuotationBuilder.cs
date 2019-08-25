using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
    public class QuotationBuilder
    {
        public QuotationBuilder(EntityTypeConfiguration<Quotation> builder)
        {
            builder.HasRequired(a => a.Customer).WithMany(b => b.Quotations).HasForeignKey(a => a.CustomerId);
            builder.Property(b => b.Address).HasMaxLength(4000);
            builder.Property(b => b.RefText).HasMaxLength(4000);
            builder.Property(b => b.Created).HasMaxLength(100);
            builder.Property(b => b.MobilePhone).HasMaxLength(20).IsRequired();
            builder.Property(b => b.Description).HasMaxLength(4000);
           
            builder.HasRequired(a => a.Product).WithMany(b => b.Quotations).HasForeignKey(a => a.ProductId);
           
            builder.HasOptional(a => a.Tax).WithMany(b => b.Quotations).HasForeignKey(a => a.TaxId);

        }
    }
}
