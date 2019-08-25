using Autofac;
using Autofac.Integration.Mvc;
using MyERP.Admin;
using MyERP.Data;
using MyERP.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyERP.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.Register(c => HttpContext.Current).InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<CityService>().As<ICityService>();
            builder.RegisterType<CountryService>().As<ICountryService>();
            builder.RegisterType<BankService>().As<IBankService>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<InvoiceService>().As<InvoiceService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<QuotationService>().As<IQuotationService>();
            builder.RegisterType<ReceiptService>().As<IReceiptService>();
            builder.RegisterType<SupplierService>().As<ISupplierService>();
            builder.RegisterType<TaxService>().As<ITaxService>();
            builder.RegisterType<WarehouseService>().As<IWarehouseService>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            new AutoMapperConfig().Initialize();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
