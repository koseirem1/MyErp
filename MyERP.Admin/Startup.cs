﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyERP.Admin.Startup))]
namespace MyERP.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
