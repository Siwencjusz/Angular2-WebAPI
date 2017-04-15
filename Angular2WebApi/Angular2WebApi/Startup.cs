using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using Template.DAL.Automapper;

[assembly: OwinStartup(typeof(Angular2WebApi.Startup))]

namespace Angular2WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            AutofacConfig.SetUpAutofac();
            AutomapperConfig.Configuration();

            ConfigureAuth(app);
            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
