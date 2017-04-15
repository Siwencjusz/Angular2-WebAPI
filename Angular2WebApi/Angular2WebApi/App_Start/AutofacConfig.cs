using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Template.BLL.Autofac;
using Template.DAL.Autofac;

namespace Angular2WebApi
{
    public class AutofacConfig
    {
        public static void SetUpAutofac()
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(WebApiApplication).Assembly).PropertiesAutowired();
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ManagerModule());
            builder.RegisterModule(new EFModule());
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var WebApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = WebApiResolver;
            var MvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(MvcResolver);
        }
    }
}