﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAppTemplate.Web.Startup))]

namespace MVCAppTemplate.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
