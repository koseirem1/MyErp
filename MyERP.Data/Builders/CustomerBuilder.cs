﻿using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data.Builders
{
    public class CustomerBuilder
    {
        public CustomerBuilder(EntityTypeConfiguration<Customer> builder)
        {
            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(50).IsRequired();
            builder.Ignore(b => b.FullName);
            builder.Property(b => b.MobilePhone).HasMaxLength(20).IsRequired();
            builder.Property(b => b.Email).HasMaxLength(100);
            builder.Property(b => b.Company).HasMaxLength(100).IsRequired();
            builder.Property(b => b.Address).HasMaxLength(4000);
            builder.HasOptional(p => p.Country).WithMany(w => w.Customers).HasForeignKey(p => p.CountryId);
            builder.HasOptional(p => p.City).WithMany(w => w.Customers).HasForeignKey(p => p.CityId);
            builder.Property(b => b.Photo).HasMaxLength(200);
            

        }

    }
}
