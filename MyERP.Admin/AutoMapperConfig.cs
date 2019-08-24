using AutoMapper.Configuration;
using MyERP.Admin.Models;
using MyERP.Model;


namespace MyERP.Admin
{
    public class AutoMapperConfig
    {
            public void Initialize()
            {
                var cfg = new MapperConfigurationExpression();
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                cfg.CreateMap<Customer, CustomerViewModel>().ForMember(

                       dest => dest.CityName,
                       opt => opt.MapFrom(src => src.City.Name)).ForMember(
                       dest => dest.CountryName,
                       opt => opt.MapFrom(src => src.Country.Name)).ReverseMap()
                   .ForMember(dest => dest.Country, opt => opt.Ignore())
                   .ForMember(dest => dest.City, opt => opt.Ignore()).
                   ForMember(dest => dest.Invoices, opt => opt.Ignore()).
                   ForMember(dest => dest.Orders, opt => opt.Ignore()).
                   ForMember(dest => dest.Quotations, opt => opt.Ignore()).
                   ForMember(dest => dest.Receipts, opt => opt.Ignore());

                 cfg.CreateMap<Bank, BankViewModel>().ForMember(

                      dest => dest.CityName,
                      opt => opt.MapFrom(src => src.City.Name)).ForMember(
                      dest => dest.CountryName,
                      opt => opt.MapFrom(src => src.Country.Name)).ReverseMap()
                  .ForMember(dest => dest.Country, opt => opt.Ignore())
                  .ForMember(dest => dest.City, opt => opt.Ignore()).
                  ForMember(dest => dest.Receipts, opt => opt.Ignore());

            cfg.CreateMap<City, CityViewModel>().ForMember(
           dest => dest.CountryName,
           opt => opt.MapFrom(src => src.Country.Name)).ReverseMap().
           ForMember(dest => dest.Country, opt => opt.Ignore()).
           ForMember(dest => dest.Customers, opt => opt.Ignore()).
           ForMember(dest => dest.Suppliers, opt => opt.Ignore()).
           ForMember(dest => dest.Banks, opt => opt.Ignore());

            cfg.CreateMap<Country, CountryViewModel>().ReverseMap().ForMember(
               dest => dest.Cities, opt => opt.Ignore()).ForMember(
               dest => dest.Customers, opt => opt.Ignore()).ForMember(
               dest => dest.Banks, opt => opt.Ignore()).ForMember(
               dest => dest.Suppliers, opt => opt.Ignore());

            cfg.CreateMap<Invoice, InvoiceViewModel>().ForMember(
           dest => dest.CustomerFullName,
           opt => opt.MapFrom(src => src.Customer.FullName)).ForMember(
           dest => dest.ProductName,
           opt => opt.MapFrom(src => src.Product.Name)).ForMember(
           dest => dest.TaxName,
           opt => opt.MapFrom(src => src.Tax.Name)).ReverseMap().ForMember(
               dest => dest.Customer, opt => opt.Ignore()).ForMember(
               dest => dest.Product, opt => opt.Ignore()).ForMember(
               dest => dest.Tax, opt => opt.Ignore());

            cfg.CreateMap<Order,OrderViewModel>().ForMember(
             dest => dest.CustomerFullName,
            opt => opt.MapFrom(src => src.Customer.FullName)).ForMember(
            dest => dest.ProductName,
             opt => opt.MapFrom(src => src.Product.Name)).ForMember(
             dest => dest.TaxName,
             opt => opt.MapFrom(src => src.Tax.Name)).ReverseMap().ForMember(
              dest => dest.Customer, opt => opt.Ignore()).ForMember(
              dest => dest.Product, opt => opt.Ignore()).ForMember(
              dest => dest.Tax, opt => opt.Ignore());

            cfg.CreateMap<Product, ProductViewModel>()
            .ReverseMap().ForMember(
             dest => dest.Orders, opt => opt.Ignore()).ForMember(
             dest => dest.Invoices, opt => opt.Ignore()).ForMember(
             dest => dest.Quotations, opt => opt.Ignore());

            cfg.CreateMap<Quotation, QuotationViewModel>().ForMember(
            dest => dest.CustomerFullName,
             opt => opt.MapFrom(src => src.Customer.FullName)).ForMember(
            dest => dest.ProductName,
             opt => opt.MapFrom(src => src.Product.Name)).ForMember(
            dest => dest.TaxName,
             opt => opt.MapFrom(src => src.Tax.Name)).ReverseMap().ForMember(
             dest => dest.Customer, opt => opt.Ignore()).ForMember(
             dest => dest.Product, opt => opt.Ignore()).ForMember(
            dest => dest.Tax, opt => opt.Ignore());

            cfg.CreateMap<Receipt, ReceiptViewModel>().ForMember(
            dest => dest.CustomerFullName,
            opt => opt.MapFrom(src => src.Customer.FullName)).ForMember(
             dest => dest.BankName,
            opt => opt.MapFrom(src => src.Bank.Name)).ReverseMap().ForMember(
             dest => dest.Bank, opt => opt.Ignore()).ForMember(
             dest => dest.Customer, opt => opt.Ignore());

            cfg.CreateMap<Supplier, SupplierViewModel>().ForMember(
                  dest => dest.CityName,
                  opt => opt.MapFrom(src => src.City.Name)).ForMember(
                  dest => dest.CountryName,
                  opt => opt.MapFrom(src => src.Country.Name))
                 .ReverseMap()
              .ForMember(dest => dest.Country, opt => opt.Ignore())
              .ForMember(dest => dest.City, opt => opt.Ignore());


            cfg.CreateMap<Tax, TaxViewModel>()
            .ReverseMap().ForMember(
             dest => dest.Orders, opt => opt.Ignore()).ForMember(
             dest => dest.Invoices, opt => opt.Ignore()).ForMember(
             dest => dest.Quotations, opt => opt.Ignore());


        }
    }
    }
