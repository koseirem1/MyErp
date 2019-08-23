using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
    public class WarehouseBuilder
    {
        public WarehouseBuilder(EntityTypeConfiguration<Warehouse> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
            builder.Property(b => b.WarehouseLocation).HasMaxLength(4000);
            builder.Property(b => b.Manager).HasMaxLength(50);
        }
    }
}
