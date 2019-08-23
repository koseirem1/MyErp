using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
   public class BankBuilder
    {
        public BankBuilder(EntityTypeConfiguration<Bank> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.Property(b => b.Address).HasMaxLength(4000);
            builder.HasOptional(p => p.Country).WithMany(w => w.Banks).HasForeignKey(p => p.CountryId);
            builder.HasOptional(p => p.City).WithMany(w => w.Banks).HasForeignKey(p => p.CityId);
            builder.Property(b => b.Account).HasMaxLength(20).IsRequired();

       
        }
    }
}
