using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
    public class InvoiceBuilder
    {
        public InvoiceBuilder(EntityTypeConfiguration<Invoice> builder)
        {
            builder.HasRequired(a => a.Customer).WithMany(b => b.Invoices).HasForeignKey(a => a.Customer);
            builder.Property(b => b.Address).HasMaxLength(4000);
            builder.Property(b => b.InvoiceAddress).HasMaxLength(4000);
            builder.Property(b => b.Created).HasMaxLength(100);
            builder.Property(b => b.MobilePhone).HasMaxLength(20).IsRequired();
            builder.HasRequired(a => a.Product).WithMany(b => b.Invoices).HasForeignKey(a => a.Product);
            builder.Property(b => b.Description).HasMaxLength(4000);
            builder.HasOptional(a => a.Tax).WithMany(b => b.Invoices).HasForeignKey(a => a.TaxId);


        }
    }
}
