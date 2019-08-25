using Microsoft.AspNet.Identity.EntityFramework;
using MyERP.Data.Builders;
using MyERP.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyERP.Data
{
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, MyERP.Data.Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Quotation> Quotations { get; set; }

        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            new BankBuilder(modelBuilder.Entity<Bank>());
            new CustomerBuilder(modelBuilder.Entity<Customer>());
            new InvoiceBuilder(modelBuilder.Entity<Invoice>());
            new CityBuilder(modelBuilder.Entity<City>());
            new OrderBuilder(modelBuilder.Entity<Order>());
            new ProductBuilder(modelBuilder.Entity<Product>());
            new QuotationBuilder(modelBuilder.Entity<Quotation>());
            new CountryBuilder(modelBuilder.Entity<Country>());
            new ReceiptBuilder(modelBuilder.Entity<Receipt>());
            new SupplierBuilder(modelBuilder.Entity<Supplier>());
            new WarehouseBuilder(modelBuilder.Entity<Warehouse>());
            new TaxBuilder(modelBuilder.Entity<Tax>());
           

        }

        public System.Data.Entity.DbSet<MyERP.Admin.Models.CustomerViewModel> CustomerViewModels { get; set; }

        public System.Data.Entity.DbSet<MyERP.Admin.Models.BankViewModel> BankViewModels { get; set; }
    }
}


