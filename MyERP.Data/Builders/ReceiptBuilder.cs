using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
   public class ReceiptBuilder
    {
        public ReceiptBuilder(EntityTypeConfiguration<Receipt> builder)
        {
            builder.HasRequired(a => a.Customer).WithMany(b => b.Receipts).HasForeignKey(a => a.CustomerId);
            builder.HasOptional(a => a.Bank).WithMany(b => b.Receipts).HasForeignKey(a => a.BankId);

        }
    }
}
