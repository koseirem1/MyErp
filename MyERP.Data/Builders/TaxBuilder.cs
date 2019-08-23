using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
    public class TaxBuilder
    {
        public TaxBuilder(EntityTypeConfiguration<Tax> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
        }
    }
}
